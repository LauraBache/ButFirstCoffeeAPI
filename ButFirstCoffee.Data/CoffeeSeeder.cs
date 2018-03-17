using ButFirstCoffee.Domain;
using System;
using System.Linq;

namespace ButFirstCoffee.Data
{
    public class CoffeeSeeder
    {
        private readonly CoffeeContext _ctx;

        public CoffeeSeeder(CoffeeContext ctx)
        {
            _ctx = ctx;
        }

        public void Seed()
        {
            _ctx.Database.EnsureCreated();

            if (!_ctx.Beverages.Any())
            {
                // Beverage categories
                BeverageCategory coffee = new BeverageCategory()
                {
                    Name = "Coffee"
                };
                _ctx.BeverageCategories.Add(coffee);

                // Beverage categories
                BeverageCategory tea = new BeverageCategory()
                {
                    Name = "Tea"
                };
                _ctx.BeverageCategories.Add(tea);

                // Beverages
                Beverage houseBlend = new Beverage()
                {
                    Description = "House Blend",
                    DetailedDescription = "Aroma, body and flavor all in balance—with tastes of nuts and cocoa brought out by the roast.",
                    Price = 45m,
                    Category = coffee
                };
                _ctx.Beverages.Add(houseBlend);

                Beverage darkRoast = new Beverage()
                {
                    Description = "Dark Roast",
                    DetailedDescription = "Roasted to emphasize the smoky, toasty flavors of the roast itself.",
                    Price = 40m,
                    Category = coffee
                };
                _ctx.Beverages.Add(darkRoast);

                Beverage decaf = new Beverage()
                {
                    Description = "Decaf",
                    DetailedDescription = "For the ones who want to cut down on the caffeine but not the enjoyment of coffee.",
                    Price = 35m,
                    Category = coffee
                };
                _ctx.Beverages.Add(decaf);

                Beverage expresso = new Beverage()
                {
                    Description = "Expresso",
                    DetailedDescription = "This dark-roasted blend produces a smoky aroma and tastes great.",
                    Price = 40m,
                    Category = coffee
                };
                _ctx.Beverages.Add(expresso);

                Beverage chai = new Beverage()
                {
                    Description = "Tiger Spice Chai",
                    DetailedDescription = "David Rio's signature and award-winning Chai recipe based on black tea.",
                    Price = 40m,
                    Category = tea
                };
                _ctx.Beverages.Add(chai);

                Beverage earlGrey = new Beverage()
                {
                    Description = "Earl Grey",
                    DetailedDescription = "Classic Earl Grey. A delicate tea with a delicious twist of citrusy bergamot.",
                    Price = 25m,
                    Category = tea
                };
                _ctx.Beverages.Add(earlGrey);


                // Condiments
                Condiment milk = new Condiment()
                {
                    Description = "Milk",
                    DetailedDescription = "Steamed",
                    Price = 5m
                };
                _ctx.Condiments.Add(milk);

                Condiment soy = new Condiment()
                {
                    Description = "Soy",
                    DetailedDescription = "Steamed",
                    Price = 7m
                };
                _ctx.Condiments.Add(soy);

                Condiment mocha = new Condiment()
                {
                    Description = "Mocha",
                    DetailedDescription = "Bittersweet mocha sauce",
                    Price = 15m
                };
                _ctx.Condiments.Add(mocha);

                Condiment whip = new Condiment()
                {
                    Description = "Whip",
                    DetailedDescription = "Organic cream",
                    Price = 5m
                };
                _ctx.Condiments.Add(whip);

                Condiment vanilla = new Condiment()
                {
                    Description = "Vanilla syrup",
                    DetailedDescription = "Sweet touch of vanilla flavor",
                    Price = 5m
                };
                _ctx.Condiments.Add(vanilla);

                Condiment caramel = new Condiment()
                {
                    Description = "Caramel syrup",
                    DetailedDescription = "Sweet touch of caramel flavor",
                    Price = 5m
                };
                _ctx.Condiments.Add(caramel);

                Condiment hazelnut = new Condiment()
                {
                    Description = "Hazelnut syrup",
                    DetailedDescription = "Sweet touch of hazelnut flavor",
                    Price = 5m
                };
                _ctx.Condiments.Add(hazelnut);


                // Sales
                Sale houseSale = new Sale()
                {
                    Name = "Sale on House Blend",
                    Description = "Try our amazing house blend with a 20 percent discount this week.",
                    Type = ESaleType.On_Beverage,
                    Percent = 20
                };
                _ctx.Sales.Add(houseSale);

                Sale chaiSale = new Sale()
                {
                    Name = "Sale on Tiger Spice Chai",
                    Description = "Try David Rio's signature and award-winning Tiger Spice Chai with a 20 percent discount on the total product this week.",
                    Type = ESaleType.On_TotalBeverage,
                    Percent = 20
                };
                _ctx.Sales.Add(chaiSale);


                // Beverage sales
                BeverageSale houseBeveragesale = new BeverageSale()
                {
                    BeverageId = houseBlend.Id,
                    SaleId = houseSale.Id,
                    DateFrom = DateTime.Now,
                    DateTo = DateTime.Now.AddDays(7)
                };
                _ctx.BeverageSales.Add(houseBeveragesale);

                BeverageSale chaiBeveragesale = new BeverageSale()
                {
                    BeverageId = chai.Id,
                    SaleId = chaiSale.Id,
                    DateFrom = DateTime.Now,
                    DateTo = DateTime.Now.AddDays(7)
                };
                _ctx.BeverageSales.Add(chaiBeveragesale);


                // Orders
                Order coffeeOrder = new Order()
                {
                    OrderDate = DateTime.Now,
                    Completed = true
                };
                _ctx.Orders.Add(coffeeOrder);

                Order latteOrder = new Order()
                {
                    OrderDate = DateTime.Now.AddDays(-2),
                    Completed = true
                };
                _ctx.Orders.Add(latteOrder);


                // Order items
                OrderItem coffeeItem = new OrderItem()
                {
                    Beverage = darkRoast,
                    Description = darkRoast.Description,
                    Quantity = 2,
                    UnitPrice = darkRoast.Price,
                    Order = coffeeOrder
                };
                _ctx.OrderItems.Add(coffeeItem);
                
                OrderItem latteItem = new OrderItem()
                {
                    Beverage = houseBlend,
                    Description = $"{darkRoast.Description} with {milk.Description}",
                    Quantity = 1,
                    UnitPrice = (houseBlend.Price + milk.Price),
                    Order = latteOrder
                };
                _ctx.OrderItems.Add(latteItem);

                _ctx.SaveChanges();
            }
        }
    }
}
