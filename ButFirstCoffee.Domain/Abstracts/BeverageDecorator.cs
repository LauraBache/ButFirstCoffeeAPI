using System.ComponentModel.DataAnnotations.Schema;

namespace ButFirstCoffee.Domain
{
    [NotMapped]
    public abstract class BeverageDecorator: BeverageComponent
    {
        public abstract string GetDescription();
    }
}
