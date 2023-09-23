using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TerosOpenBanking.Application.Mediator.Query;

namespace TerosOpenBanking.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RequestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Route("{isCheck}")]
        public async Task<IActionResult> GetDataAsync(bool isCheck)
        {
            var query = new GetDataQuery(isCheck);
            var listData = await _mediator.Send(query);

            if (listData == null)
                return NotFound();

            return Ok(listData);
        }
    }
}
