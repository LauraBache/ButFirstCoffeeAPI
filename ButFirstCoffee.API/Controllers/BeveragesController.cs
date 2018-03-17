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
    public class BeveragesController :  Controller
    {
        private readonly IBeverageRepository _beverageRepo;
        private readonly ILogger<BeveragesController> _logger;
        private readonly IMapper _mapper;

        public BeveragesController(IBeverageRepository beverageRepo, ILogger<BeveragesController> logger, IMapper mapper)
        {
            _beverageRepo = beverageRepo;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(int? categoryId = null)
        {
            try
            {
                var beverages = _mapper.Map<IEnumerable<Beverage>, IEnumerable<BeverageViewModel>>(_beverageRepo.GetBeveragesWithCategory(categoryId));

                if (beverages.Count() > 0)
                {
                    return Ok(beverages);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get beverages: {ex}");

                return BadRequest("Failed to get beverages");
            }
        }
    }
}
