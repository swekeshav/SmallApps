using Microsoft.EntityFrameworkCore;

namespace Todo.API.Database;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
}