using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAPI.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestAPI.Common;

namespace Test.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HouseHoldsController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly ILogger<HouseHoldsController> _logger;
        public HouseHoldsController(UnitOfWork unitOfWork, ILogger<HouseHoldsController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetHouseholds(string state)
        {
            //Write log
            _logger.LogInformation(Const.Log_Info_Households + state);

            if (state == null)
            {
                return NotFound();
            }
            var lstState = Array.ConvertAll(state.Split(Const.Comma), s => int.Parse(s));
            return Ok(_unitOfWork.HouseHold.Get(lstState.ToList()));
        }
    }
}
