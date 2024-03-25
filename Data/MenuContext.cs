using Menu.Models;
using Microsoft.EntityFrameworkCore;

namespace Menu.Data
{
  public class MenuContext : DbContext
  {
    public MenuContext(DbContextOptions<MenuContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<DishIngredient>()
        .HasKey(di => new { di.DishId, di.IngredientId });

      modelBuilder.Entity<DishIngredient>()
        .HasOne(d => d.Dish)
        .WithMany(di => di.DishIngredients)
        .HasForeignKey(d => d.DishId);

      modelBuilder.Entity<DishIngredient>()
        .HasOne(i => i.Ingredient)
        .WithMany(di => di.DishIngredients)
        .HasForeignKey(i => i.IngredientId);

      modelBuilder.Entity<Dish>().HasData(
        new Dish { Id = 1, Name = "Pepperoni", ImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.tripadvisor.com%2FRestaurant_Review-g1028716-d12208668-Reviews-Pizz_a_Porter-Mostoles.html&psig=AOvVaw2s51yVxaDguFpa4yf6vh94&ust=1711416139558000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCIjd3J6gjoUDFQAAAAAdAAAAABAJ", Price = 9.99 },
      );

      modelBuilder.Entity<Ingredient>().HasData(
        new Ingredient { Id = 1, Name = "Pepperoni" },
        new Ingredient { Id = 2, Name = "Cheese" },
        new Ingredient { Id = 3, Name = "Sauce" },
        new Ingredient { Id = 4, Name = "Dough" }
      );

      modelBuilder.Entity<DishIngredient>().HasData(
        new DishIngredient { DishId = 1, IngredientId = 1 },
        new DishIngredient { DishId = 1, IngredientId = 2 },
        new DishIngredient { DishId = 1, IngredientId = 3 },
        new DishIngredient { DishId = 1, IngredientId = 4 }
      );

      base.OnModelCreating(modelBuilder);
    }

    public DbSet<Dish> Dishes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<DishIngredient> DishIngredients { get; set; }
  }
}
