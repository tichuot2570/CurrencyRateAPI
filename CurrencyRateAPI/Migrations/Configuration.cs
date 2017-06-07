namespace CurrencyRateAPI.Migrations
{
    using CurrencyRateAPI.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CurrencyRateAPI.Models.CurrencyRateAPIContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CurrencyRateAPI.Models.CurrencyRateAPIContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Currencies.AddOrUpdate(x => x.Id,
           new Currency {Id = 1, Name = "Swiss franc", Category = "Currency", Rate = 0.90M },
           new Currency { Id= 2,Name = "Euro", Category = "Currency", Rate = 0.89M },
           new Currency {Id=3, Name = "Singapore Dollar", Category = "Currency", Rate = 1.389M }
               );

            context.Countries.AddOrUpdate(x => x.CountryId,
                new Country() {CountryId =1, CountryName = "Switzerland", CurrencyId = 1 },
                new Country() { CountryId = 2, CountryName = "France", CurrencyId = 2 },
                new Country() { CountryId = 3, CountryName = "Singapore", CurrencyId = 3 },
                new Country() { CountryId = 4, CountryName = "Spain", CurrencyId = 2 },
                new Country() { CountryId = 5, CountryName = "Finland", CurrencyId = 2 }
                );
        }
    }
}
