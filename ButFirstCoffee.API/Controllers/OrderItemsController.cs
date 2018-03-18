using AutoMapper;
using ButFirstCoffee.API.ViewModels;
using ButFirstCoffee.Data;
using ButFirstCoffee.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace ButFirstCoffee.API.Controllers
{
    [Route("api/orders/{orderid}/items")]
    public class OrderItemsController: Controller
    {
        private readonly IOrderItemRepository _orderItemRepo;
        private readonly ICondimentRepository _condimentRepo;
        private readonly ILogger<OrderItemsController> _logger;
        private readonly IMapper _mapper;

        public OrderItemsController(IOrderItemRepository orderItemRepo, ICondimentRepository condimentRepo, ILogger<OrderItemsController> logger, IMapper mapper)
        {
            _orderItemRepo = orderItemRepo;
            _condimentRepo = condimentRepo;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Post([FromBody]OrderItemViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newItem = _mapper.Map<OrderItemViewModel, OrderItem>(model);

                    var addedOrderItem = _orderItemRepo.AddOrderItem(newItem);

                    return Created($"/api/orders/{addedOrderItem.OrderId}/items/{addedOrderItem.Id}", _mapper.Map<OrderItem, OrderItemViewModel>(addedOrderItem));
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get order: {ex}");

                return BadRequest("Failed to get order");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, int condimentId, [FromBody]OrderItemViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var oldItem = _orderItemRepo.GetOrderItemWithBeverageAndSale(id);
                if (oldItem == null)
                {
                    return NotFound($"Could not find an order item with an id of {id}");
                }

                var condiment = _condimentRepo.GetCondiment(condimentId);
                if (condiment == null)
                {
                    return NotFound($"Could not find an condiment with an id of {condimentId}");
                }

                var toBeUpdatedItem = _mapper.Map(model, oldItem);
                var updatedItem = _orderItemRepo.UpdateOrderItemWithCondiment(toBeUpdatedItem, condiment);

                return Ok(_mapper.Map<OrderItemViewModel>(updatedItem));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to update order item: {ex}");

                return BadRequest("Failed to update order item");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var item = _orderItemRepo.GetOrderItemWithBeverageAndSale(id);
                if (item == null)
                {
                    return NotFound($"Could not find an order item with an id of {id}");
                }

                _orderItemRepo.DeleteOrderItem(item);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to delete order item: {ex}");

                return BadRequest("Failed to delete order item");
            }
        }
    }
}
