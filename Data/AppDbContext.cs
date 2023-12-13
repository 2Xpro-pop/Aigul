using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aigul.OptimizedModels;
using Microsoft.EntityFrameworkCore;

namespace Aigul.Data;
public class AppDbContext : DbContext
{
    public DbSet<User> Users
    {
        get; set;
    }

    public DbSet<Room> Rooms
    {
        get; set;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=helloapp.db");
        optionsBuilder.UseModel(AppDbContextModel.Instance);
    }
}
