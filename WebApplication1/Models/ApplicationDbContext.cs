// Models/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApplication1.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
}
