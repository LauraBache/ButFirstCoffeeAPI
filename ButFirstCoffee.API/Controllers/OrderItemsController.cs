using AutoMapper;
using ButFirstCoffee.API.ViewModels;
using ButFirstCoffee.Data;
using ButFirstCoffee.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ButFirstCoffee.API.Controllers
{
    [Route("api/orders/{orderid}/items")]
    public class OrderItemsController: Controller
    {
        private readonly IOrderItemRepository _orderItemRepo;
        private readonly ILogger<OrderItemsController> _logger;
        private readonly IMapper _mapper;

        public OrderItemsController(IOrderItemRepository orderItemRepo, ILogger<OrderItemsController> logger, IMapper mapper)
        {
            _orderItemRepo = orderItemRepo;
            _logger = logger;
            _mapper = mapper;
        }

        //TODO create a call for creating an item
        [HttpPost]
        public IActionResult Post([FromBody]OrderItemViewModel model)
        {
            //try
            //{
            //    if (ModelState.IsValid)
            //    {
            //        var newItem = _mapper.Map<OrderItemViewModel, OrderItem>(model);

            //        var addedOrderItem = _orderItemRepo.AddOrderItem(newItem);

            //        return Created($"/api/orders/{createdOrder.Id}", _mapper.Map<Order, OrderViewModel>(createdOrder));
            //    }
            //    else
            //    {
            //        return BadRequest(ModelState);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError($"Failed to get order: {ex}");

            //    return BadRequest("Failed to get order");
            //}
            return null;
        }

        //TODO create a call for updating an item

        //TODO create a call for deleting an item
    }
}
