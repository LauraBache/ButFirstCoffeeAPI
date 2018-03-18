using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ButFirstCoffee.API.ViewModels
{
    public class OrderItemViewModel
    {
        public int? ItemId { get; set; }
        [Required]
        public int BeverageId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        public int? OrderId { get; set; }
    }
}
