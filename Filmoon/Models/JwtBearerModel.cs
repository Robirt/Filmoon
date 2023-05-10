namespace Filmoon.Models;

public class JwtBearerModel
{
    public JwtBearerModel()
    {
        
    }

    public JwtBearerModel(int nameIdentifier, string name, string role)
    {
        NameIdentifier = nameIdentifier;
        Name = name;
        Role = role;
    }

    public int NameIdentifier { get; set; }

    public string Name { get; set; }

    public string Role { get; set; }
}
