using System;
using System.Collections.Generic;
using WebApplication1.Models;
namespace WebApplication1.Models;

public partial class Contribution
{
    public int ContribId { get; set; }

    public string? Fname { get; set; }

    public string? Lname { get; set; }

    public string? Title { get; set; }

    public string? Path { get; set; }

    public string? Course { get; set; }

    public string? Type { get; set; }

    public string? Link { get; set; }

    public DateTime? Date { get; set; }
}
