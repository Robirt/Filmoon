using System.Collections.Generic;

namespace Filmoon.Models;

public class RouteModel
{
    public RouteModel(string name)
    {
        Name = name;
    }

    public RouteModel(string name, List<string> roles) : this(name)
    {
        Roles = roles;
    }

    public string Name { get; set; } = string.Empty;

    public List<string> Roles { get; set; } = new();
}
