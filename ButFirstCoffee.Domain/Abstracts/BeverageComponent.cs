using System.ComponentModel.DataAnnotations.Schema;

namespace ButFirstCoffee.Domain
{
    [NotMapped]
    public abstract class BeverageComponent
    {
        public string Description { get; set; }

        public string GetDescription()
        {
            return this.Description;
        }

        public abstract decimal GetCost();
    }
}
