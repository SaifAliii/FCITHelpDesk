using System;
using System.Collections.Generic;
using WebApplication1.Models;
namespace WebApplication1.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Fname { get; set; }

    public string? Lname { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string IsAdmin { get; set; } = null!;
}
