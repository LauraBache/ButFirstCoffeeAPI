using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ButFirstCoffee.API.ViewModels
{
    public class OrderViewModel
    {
        public int? OrderId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public IEnumerable<OrderItemViewModel> OrderItems { get; set; }
        [Required]
        public bool Completed { get; set; }
    }
}
