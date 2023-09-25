using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TerosOpenBanking.Application.Dto;
using TerosOpenBanking.Application.Mediator.Commands;
using TerosOpenBanking.Application.Mediator.Query;
using TerosOpenBanking.Infra.BaseApi.Interface;

namespace TerosOpenBanking.Application.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class RequestController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IClientApi _serviceApi;
        private readonly IConfiguration _configuration;
        public RequestController(IMediator mediator, IClientApi serviceApi, IConfiguration configuration)
        {
            _mediator = mediator;
            _serviceApi = serviceApi;
            _configuration = configuration;
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

        [HttpPost, Route("/save")]
        public async Task<IActionResult> Save()
        {
            var requestList = await _serviceApi.SendPostAsync(_configuration["UrlBase"]);
            var requestDtosList = JsonConvert.DeserializeObject<List<RequestDto>>(requestList);

            foreach (RequestDto requestDto in requestDtosList)
            {
                await _mediator.Send(new BaseObjectCommand()
                {
                    OrganizationId = requestDto.OrganisationId,
                    Name = requestDto.AuthorisationServers.FirstOrDefault().CustomerFriendlyName,
                    Image = requestDto.AuthorisationServers.FirstOrDefault().CustomerFriendlyLogoUri,
                    Discovery = requestDto.AuthorisationServers.FirstOrDefault().PayloadSigningCertLocationUri
                });
            }
            return Ok();
        }
    }
}
