using Microsoft.EntityFrameworkCore;
using BeastTimesheet.Shared.Model;

public class BloggingContext : DbContext
{
    public DbSet<Blog>? Blogs { get; set; }
    public DbSet<Post>? Posts { get; set; }

    public BloggingContext(DbContextOptions<BloggingContext> options) : base(options) { }
}