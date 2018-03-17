using AutoMapper;
using ButFirstCoffee.Data;
using ButFirstCoffee.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace ButFirstCoffee.API.Controllers
{
    [Route("api/[Controller]")]
    public class BeverageCategoriesController : Controller
    {
        private readonly IBeverageCategoryRepository _beverageCategoryRepo;
        private readonly ILogger<BeverageCategoriesController> _logger;
        private readonly IMapper _mapper;

        public BeverageCategoriesController(IBeverageCategoryRepository beverageCategoryRepo, ILogger<BeverageCategoriesController> logger,
            IMapper mapper)
        {
            _beverageCategoryRepo = beverageCategoryRepo;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<BeverageCategory>, IEnumerable<BeverageCategoryViewModel>>(_beverageCategoryRepo.GetBeverageCategories()));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get beverage categories: {ex}");

                return BadRequest("Failed to get beverage categories");
            }
        }
    }
}
