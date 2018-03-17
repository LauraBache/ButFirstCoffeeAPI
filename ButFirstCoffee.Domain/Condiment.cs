using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ButFirstCoffee.Domain
{
    public class Condiment: CondimentDecorator
    {
        public int Id { get; set; }
        public string DetailedDescription { get; set; }
        public decimal Price { get; set; }
        [NotMapped]
        public BeverageComponent Beverage { get; set; }

        /// <summary>
        /// For creating a condiment object that should be saved in persisent memory
        /// </summary>
        public Condiment()
        {

        }

        /// <summary>
        /// For creating a condiment object that should be used to decorate a beverage object
        /// </summary>
        /// <param name="description"></param>
        /// <param name="price"></param>
        /// <param name="beverage"></param>
        public Condiment(string description, decimal price, BeverageComponent beverage)
        {
            this.Description = description;
            this.Price = price;
            this.Beverage = beverage;
        }

        public override string GetDescription()
        {
            string decoratedDescription = $"{this.Beverage.GetDescription()}, {this.Description}";

            return decoratedDescription;
        }

        public override decimal GetCost()
        {
            decimal cost = this.Beverage.GetCost() + this.Price;

            return cost;
        }
    }
}
