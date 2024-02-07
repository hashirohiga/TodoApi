using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace TodoApi.Models;

public class TodoContext : DbContext
{

    public TodoContext(DbContextOptions<TodoContext> options)
    : base(options)
    {
    }
        

    public DbSet<Statuses> Statuses { get; set; } = null!;
    public DbSet<Tasks> Tasks { get; set; } = null!;
}