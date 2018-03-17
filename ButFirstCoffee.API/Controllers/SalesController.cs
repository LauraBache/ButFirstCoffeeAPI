using AutoMapper;
using ButFirstCoffee.Data;
using ButFirstCoffee.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ButFirstCoffee.API.Controllers
{
    [Route("api/[Controller]")]
    public class SalesController: Controller
    {
        private readonly ISaleRepository _saleRepo;
        private readonly ILogger<SalesController> _logger;
        private readonly IMapper _mapper;

        public SalesController(ISaleRepository saleRepo, ILogger<SalesController> logger, IMapper mapper)
        {
            _saleRepo = saleRepo;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var currentSales = _saleRepo.GetCurrentSales();

                if (currentSales.Count() > 0)
                {
                    return Ok(_mapper.Map<IEnumerable<Sale>, IEnumerable<SaleViewModel>>(currentSales));
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get sales: {ex}");

                return BadRequest("Failed to get sales");
            }
        }
    }
}
