using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SuperShopping.AuthAPI.Models;
using SuperShopping.AuthAPI.Models.DTO;

namespace SuperShopping.AuthAPI.Services;
public class RegisterService
{
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    public readonly LinkGenerator _linkGenerator;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public RegisterService(IMapper mapper, UserManager<User> userManager, LinkGenerator linkGenerator, IHttpContextAccessor httpContextAccessor)
    {
        _mapper = mapper;
        _userManager = userManager;
        _linkGenerator = linkGenerator;
        _httpContextAccessor = httpContextAccessor;
    }


    public async Task<RegisterDto> RegisterUser(CreateUserDto createUserDto)
    {
        if (createUserDto.Password != createUserDto.RePassword)
        {
            throw new BadHttpRequestException("Both password and re-password must be equals.");
        }

        var newUser = _mapper.Map<User>(createUserDto);
        var result = await _userManager.CreateAsync(newUser, createUserDto.Password);
        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(e => e.Description).ToList();
            throw new Exception($"Error while trying to create a new user. {string.Join(", ", errors)}");
        }

        var resultRole = await _userManager.AddToRoleAsync(newUser, "user");
        if (!resultRole.Succeeded)
        {
            var errors = resultRole.Errors.Select(e => e.Description).ToList();
            throw new Exception($"Error while trying to create a new user. {string.Join(", ", errors)}");
        }

        var confirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
        //var encodedCode = HttpUtility.UrlEncode(confirmationToken);

        //var link = _linkGenerator.GetUriByAction(_httpContextAccessor.HttpContext, "ConfirmUser", "Register", new { Id = newUser.Id, Token = confirmationToken });

        var confirmation = new RegisterDto
        {
            UserName = newUser.UserName,
            ConfirmationToken = confirmationToken
        };

        return confirmation;
    }

    public async Task ActivateUser(RegisterDto registerDto)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.NormalizedUserName == registerDto.UserName.ToUpper());
        if (user == null)
        {
            throw new BadHttpRequestException("Error while activating user.");
        }

        var confirmResult = await _userManager.ConfirmEmailAsync(user, registerDto.ConfirmationToken);
        if (!confirmResult.Succeeded)
        {
            throw new BadHttpRequestException("Error while activating user.");
        }
    }
}
