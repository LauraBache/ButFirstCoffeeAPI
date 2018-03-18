using AutoMapper;
using ButFirstCoffee.Data;
using ButFirstCoffee.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ButFirstCoffee.API.Controllers
{
    [Route("api/[Controller]")]
    public class CondimentsController : Controller
    {
        private readonly ICondimentRepository _condimentRepo;
        private readonly ILogger<CondimentsController> _logger;
        private readonly IMapper _mapper;

        public CondimentsController(ICondimentRepository condimentRepo, ILogger<CondimentsController> logger, IMapper mapper)
        {
            _condimentRepo = condimentRepo;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var condiments = _condimentRepo.GetCondiments();

                if (condiments.Count() > 0)
                {
                    return Ok(_mapper.Map<IEnumerable<Condiment>, IEnumerable<CondimentViewModel>>(condiments));
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get condiments: {ex}");

                return BadRequest("Failed to get condiments");
            }
        }
    }
}
