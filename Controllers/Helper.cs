using WebApplication1.Models;
using System;

namespace WebApplication1.Controllers
{
    public class Helper
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        //public static User? loggedInUser = null;
        public static User? loggedInUser = new() { Id = 1, Fname = "Saif", Lname = "Ali", Email = "BSEF20M026", IsAdmin = "N", Password = "123456" };
        public static List<string> Courses = new List<string>()
            {
                "Programming Fundamentals",
                "Object Oriented Programming",
                "Data Structures & Algorithm",
                "Linear Algebra",
                "Intro To Computing",
                "Enterprise & Application Development",
                "Analysis Of Algorithm",
                "Sociology",
                "Computer Networks"
            };
}
}
