namespace Filmoon.Models;

public class RouteModel
{
    public RouteModel(string name)
    {
        Name = name;
    }

    public string Name { get; set; } = string.Empty;
}
