﻿using Microsoft.EntityFrameworkCore;

namespace Todo.API.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public virtual DbSet<TodoItem> TodoItems => Set<TodoItem>();
}
