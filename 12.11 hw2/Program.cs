using System;
using System.Collections.Generic;
using System.Linq;

namespace hw
{
    class Good
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
    }

    class Program
    {
        static void Main()
        {
            List<Good> things = new List<Good>()
            {
                new Good() { Id = 1, Title = "Nokia 1100", Price = 450.99, Category = "Mobile" },
                new Good() { Id = 2, Title = "Iphone 4", Price = 5000, Category = "Mobile" },
                new Good() { Id = 3, Title = "Refrigerator 5000", Price = 2555, Category = "Kitchen" },
                new Good() { Id = 4, Title = "Mixer", Price = 150, Category = "Kitchen" },
                new Good() { Id = 5, Title = "Magnitola", Price = 1499, Category = "Car" },
                new Good() { Id = 6, Title = "Samsung Galaxy", Price = 3100, Category = "Mobile" },
                new Good() { Id = 7, Title = "Auto Cleaner", Price = 2300, Category = "Car" },
                new Good() { Id = 8, Title = "Oven", Price = 700, Category = "Kitchen" },
                new Good() { Id = 9, Title = "Siemens Turbo", Price = 3199, Category = "Mobile" },
                new Good() { Id = 10, Title = "Lighter", Price = 150, Category = "Car" }
            };

            //1
            var price_up = things
                .Where(g => g.Category == "Mobile" && g.Price > 1000)
                .ToList();

            Console.WriteLine("Mobile with price greater than 1000:");
            foreach (var good in price_up)
            {
                Console.WriteLine($"Title: {good.Title}, Price: {good.Price}");
            }

            //2
            var not_kitchen = things
                .Where(g => g.Category != "Kitchen" && g.Price > 1000)
                .Select(g => new { g.Title, g.Price })
                .ToList();

            Console.WriteLine("\nNot kitchen things with price greater than 1000:");
            foreach (var good in not_kitchen)
            {
                Console.WriteLine($"Title: {good.Title}, Price: {good.Price}");
            }

            //3
            double avarage_price = things
                .Select(g => g.Price)
                .Average();

            Console.WriteLine($"\nAverage price of all things: {avarage_price}");

            //4
            var rear_category = things
                .Select(g => g.Category)
                .Distinct()
                .ToList();

            Console.WriteLine("\nRare categories:");
            foreach (var category in rear_category)
            {
                Console.WriteLine(category);
            }

            //5
            var sort_things = things
                .OrderBy(g => g.Title)
                .Select(g => new { g.Title, g.Category })
                .ToList();

            Console.WriteLine("\nThings sorted by alphabet by title:");
            foreach (var good in sort_things)
            {
                Console.WriteLine($"Title: {good.Title}, Category: {good.Category}");
            }

            //6
            int car_count = things
                .Count(g => g.Category == "Car" || g.Category == "Mobile");

            Console.WriteLine($"\nTotal number of things in car and mobile categories: {car_count}");

            //7
            var category_count = things
                .GroupBy(g => g.Category)
                .Select(group => new { Category = group.Key, Count = group.Count() })
                .ToList();

            Console.WriteLine("\nCount of things in category:");
            foreach (var category in category_count)
            {
                Console.WriteLine($"Category: {category.Category}, Count: {category.Count}");
            }
        }
    }
}