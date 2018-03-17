using System.ComponentModel.DataAnnotations.Schema;

namespace ButFirstCoffee.Domain
{
    [NotMapped]
    public abstract class CondimentDecorator: BeverageComponent
    {
        public abstract string GetDescription();
    }
}
