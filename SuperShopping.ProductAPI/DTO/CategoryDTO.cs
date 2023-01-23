namespace SuperShopping.ProductAPI.DTO;
public class CategoryDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
}


public class CategoryCreationDTO
{
    public string Name { get; set; }
}

public class CategoryUpdateDTO
{
    public string Name { get; set; }
}