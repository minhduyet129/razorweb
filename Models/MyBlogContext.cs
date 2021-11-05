using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace entityframework.Models
{
  public class MyBlogContext : DbContext
  {
    public MyBlogContext(DbContextOptions<MyBlogContext> options) : base(options)
    {
    }

    protected MyBlogContext()
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder builder){
      base.OnConfiguring(builder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder){
      base.OnModelCreating(modelBuilder);
    }
    public DbSet<Article> articles{get;set;}
  }
}