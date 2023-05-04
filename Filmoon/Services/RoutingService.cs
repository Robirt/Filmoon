using Filmoon.Models;
using System.Collections.Generic;

namespace Filmoon.Services;

public class RoutingService
{
    public static List<RouteModel> Routes { get; set; } = new List<RouteModel>()
    {
        new RouteModel("Home"),
        new RouteModel("Movies"),
        new RouteModel("Rentals"),
        new RouteModel("Contact"),
        new RouteModel("Users"),
    };
}
