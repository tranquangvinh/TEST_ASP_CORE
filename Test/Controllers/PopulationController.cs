using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Models;
using CoreAPI.Reponsitories.ModelsRepository;
using CoreAPI.UnitOfWorks;
using Microsoft.Extensions.Logging;
using TestAPI.Common;

namespace Test.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PopulationController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly ILogger<HouseHoldsController> _logger;
        public PopulationController(UnitOfWork unitOfWork, ILogger<HouseHoldsController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetPopulation(string state)
        {
            //Write log
            _logger.LogInformation(Const.Log_Info_Population + state);

            if (state == null)
            {
                return NotFound();
            }
            var lstState = Array.ConvertAll(state.Split(Const.Comma), s => int.Parse(s));
            return Ok(_unitOfWork.Population.Get(lstState.ToList()));
        }
    }
}
