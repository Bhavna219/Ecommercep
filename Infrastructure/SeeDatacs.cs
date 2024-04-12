using Microsoft.EntityFrameworkCore;
using ShoppingCart.Models;
using ShoppingCart.Models.Infrastructure;

namespace ShoppingCart.Infrastructure
{
    public class SeedData
    {
        public static void SeedDatabase(DataContext context)
        {
            context.Database.Migrate();

            if (!context.Products.Any())
            {
                Category fruits = new Category { Name = "Fruits", Title= "fruits" };
                Category shirts = new Category { Name = "Shirts", Title = "shirts" };

                context.Products.AddRange(
                        new Product
                        {
                            Name = "Apples",
                            Title = "apples",
                            Description = "Juicy apples",
                            Price = 1.50M,
                            Category = fruits,
                            Image = "apples.jpg"
                        },
                        new Product
                        {
                            Name = "Bananas",
                            Title = "bananas",
                            Description = "Fresh bananas",
                            Price = 3M,
                            Category = fruits,
                            Image = "bananas.jpg"
                        },
                        new Product
                        {
                            Name = "Watermelon",
                            Title = "watermelon",
                            Description = "Juicy watermelon",
                            Price = 0.50M,
                            Category = fruits,
                            Image = "watermelon.jpg"
                        },
                        new Product
                        {
                            Name = "Grapefruit",
                            Title = "grapefruit",
                            Description = "Juicy grapefruit",
                            Price = 2M,
                            Category = fruits,
                            Image = "grapefruit.jpg"
                        },
                        new Product
                        {
                            Name = "White shirt",
                            Title = "white-shirt",
                            Description = "White shirt",
                            Price = 5.99M,
                            Category = shirts,
                            Image = "white shirt.jpg"
                        },
                        new Product
                        {
                            Name = "Black shirt",
                            Title = "black-shirt",
                            Description = "Black shirt",
                            Price = 7.99M,
                            Category = shirts,
                            Image = "black shirt.jpg"
                        },
                        new Product
                        {
                            Name = "Yellow shirt",
                            Title = "yellow-shirt",
                            Description = "Yellow shirt",
                            Price = 11.99M,
                            Category = shirts,
                            Image = "yellow shirt.jpg"
                        },
                        new Product
                        {
                            Name = "Grey shirt",
                            Title = "grey-shirt",
                            Description = "Grey shirt",
                            Price = 12.99M,
                            Category = shirts,
                            Image = "grey shirt.jpg"
                        }
                );

                context.SaveChanges();
            }
        }
    }
}
