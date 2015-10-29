namespace SearchSampleApp.Migrations
{
    using SearchSampleApp.Data;
    using SearchSampleApp.Domain;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SearchSampleApp.Data.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AppDbContext context)
        {
            context.Customers.AddOrUpdate(
                p => p.Id,
                new Customer { Id = 1, Name = "Customer One" },
                new Customer { Id = 2, Name = "Customer Two" }
                );

            context.Orders.AddOrUpdate(
                p => p.Id,
                new Order { Id = 1, Date = DateTime.Now, Total = 100, Status = "Canceled", CustomerId = 1 },
                new Order { Id = 2, Date = DateTime.Now.AddDays(-15), Total = 120, Status = "New", CustomerId = 1 },
                new Order { Id = 3, Date = DateTime.Now.AddDays(-20), Total = 180, Status = "Delivered", CustomerId = 2 },
                new Order { Id = 4, Date = DateTime.Now.AddDays(-5), Total = 1100, Status = "Canceled", CustomerId = 2 },
                new Order { Id = 5, Date = DateTime.Now.AddDays(-10), Total = 200, Status = "New", CustomerId = 2 },
                new Order { Id = 6, Date = DateTime.Now.AddDays(-2), Total = 800, Status = "New", CustomerId = 2 },
                new Order { Id = 7, Date = DateTime.Now.AddDays(-10), Total = 120, Status = "New", CustomerId = 1 },
                new Order { Id = 8, Date = DateTime.Now.AddDays(-8), Total = 180, Status = "Delivered", CustomerId = 2 },
                new Order { Id = 9, Date = DateTime.Now.AddDays(-3), Total = 1100, Status = "Canceled", CustomerId = 2 },
                new Order { Id = 10, Date = DateTime.Now.AddDays(-10), Total = 200, Status = "New", CustomerId = 1 },
                new Order { Id = 11, Date = DateTime.Now.AddDays(-12), Total = 800, Status = "New", CustomerId = 2 }
                );
        }
    }
}
