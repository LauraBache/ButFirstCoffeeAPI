using System;
using ButFirstCoffee.Data;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using ButFirstCoffee.API.ViewModels;
using AutoMapper;
using ButFirstCoffee.Domain;

namespace ButFirstCoffee.API.Controllers
{
    [Route("api/[Controller]")]
    public class OrdersController: Controller
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IBeverageRepository _beverageRepo;
        private readonly ILogger<OrdersController> _logger;
        private readonly IMapper _mapper;

        public OrdersController(IOrderRepository orderRepo, IBeverageRepository beverageRepo, ILogger<OrdersController> logger, IMapper mapper)
        {
            _orderRepo = orderRepo;
            _beverageRepo = beverageRepo;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var order = _orderRepo.GetOrderWithItems(id);

                if (order != null)
                {
                    return Ok(_mapper.Map<Order, OrderViewModel>(order));
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get order: {ex}");

                return BadRequest("Failed to get order");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]OrderViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newOrder = _mapper.Map<OrderViewModel, Order>(model);

                    var createdOrder = _orderRepo.CreateOrder(newOrder);

                    return Created($"/api/orders/{createdOrder.Id}", _mapper.Map<Order, OrderViewModel>(createdOrder));
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
        public IActionResult Put(int id, [FromBody]OrderViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var oldOrder = _orderRepo.GetOrderWithItems(id);
                var updatedOrder = _orderRepo.CompleteOrder(oldOrder);

                return Ok(_mapper.Map<OrderViewModel>(updatedOrder));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to update order: {ex}");

                return BadRequest("Failed to update order");
            }
        }
    }
}
