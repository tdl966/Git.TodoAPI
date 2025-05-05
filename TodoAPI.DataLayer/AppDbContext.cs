using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAPI.DataLayer.Entities;

namespace TodoAPI.DataLayer
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) 
        { 
        
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<TodoItemEntity> TodoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // UserEntity
            builder.Entity<UserEntity>(e =>
            {
                e.HasKey(u => u.UserId);
                e.HasIndex(u => u.UserPublicId).IsUnique();
                e.Property(u => u.Username)
                    .IsRequired()
                    .HasMaxLength(100);
                e.Property(u => u.Email)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            // CategoryEntity
            builder.Entity<CategoryEntity>(e =>
            {
                e.HasKey(c => c.CategoryId);
                e.HasIndex(c => c.CategoryPublicId).IsUnique();
                e.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            // TodoItem
            builder.Entity<TodoItemEntity>(e =>
            {
                e.HasKey(t => t.TodoItemId);
                e.HasIndex(t => t.TodoItemPublicId).IsUnique();
                e.Property(t => t.Title)
                    .IsRequired()
                    .HasMaxLength(200);
                e.Property(t => t.CreatedAt)
                    .IsRequired();

                e.HasOne(t => t.User)
                    .WithMany(u => u.TodoItems)
                    .HasForeignKey(t => t.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                e.HasOne(t => t.Category)
                    .WithMany(c => c.TodoItems)
                    .HasForeignKey(t => t.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}