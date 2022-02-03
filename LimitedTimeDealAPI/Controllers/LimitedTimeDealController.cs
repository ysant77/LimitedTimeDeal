using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LimitedTimeDealAPI.Models;
using LimitedTimeDealAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LimitedTimeDealAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LimitedTimeDealController : ControllerBase
    {
        private readonly DealService _dealService;
        public LimitedTimeDealController(DealService dealService)
        {
            _dealService = dealService;
        }
        [HttpPost]
        [Route("createdeal")]
        public async Task<IActionResult> CreateDeal([FromBody] Deal deal)
        {
            deal.IsActive = true;
            var result = await _dealService.CreateDeal(deal);
            if (result == -1)
            {
                var error = new Error();
                error.ErrorMessage = "Cannot create deal at the moment";
                return (IActionResult)error;
            }
            return NoContent();
        }

        [HttpGet]
        [Route("getdeals")]
        public async Task<List<Deal>> GetDeals()
        {
            return _dealService.GetDeals();
        }

        [HttpPost]
        [Route("claimdeal/{dealId}")]
        public async Task<IActionResult> ClaimDeal(int dealId)
        {
            var res =  _dealService.ClaimDeal(dealId);
            if(res == null)
            {
                var error = new Error();
                error.ErrorMessage = "Cannot update deal at the moment";
                return (IActionResult)error;
            }
            return Ok();
        }

        [HttpPut]
        [Route("updatedeal/{dealId}")]
        public async Task<IActionResult> UpdateDeal(int dealId, [FromBody] Deal deal)
        {
            deal.Id = dealId;
            var result = _dealService.UpdateDeal(dealId, deal);
            if(result == null)
            {
                var error = new Error();
                error.ErrorMessage = "Cannot update deal at the moment";
                return (IActionResult)error;
            }
            return Ok();
        }

        [HttpPost]
        [Route("enddeal/{dealId}")]
        public async Task<IActionResult> EndDeal(int dealId)
        {
            var result = _dealService.EndDeal(dealId);
            if (result == null)
            {
                var error = new Error();
                error.ErrorMessage = "Cannot update deal at the moment";
                return (IActionResult)error;
            }
            return Ok();
        }


    }
}
