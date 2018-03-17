using AutoMapper;
using ButFirstCoffee.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ButFirstCoffee.API.Controllers
{
    [Route("api/[Controller]")]
    public class CondimentsController
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
    }
}
