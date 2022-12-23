using System.Security.Claims;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CurrencyExchange.Application.CurrencyExchange.Commands.Exchange;
using CurrencyExchange.Application.CurrencyExchange.Common;
using CurrencyExchange.Contracts.CurrencyExchange;

namespace CurrencyExchange.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public CurrencyController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [Authorize]
        [HttpPost("exchange")]
        public async Task<IActionResult> Exchange(CurrencyExchangeRequest exchangeRequest)
        {
            var command = _mapper.Map<ExchangeCommand>(exchangeRequest);

            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                command.UserId = Convert.ToInt32(identity.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            }

            ExchangeResult exchangeResult = await _mediator.Send(command);

            var response = _mapper.Map<CurrencyExchangeResponse>(exchangeResult);

            return Ok(response);
        }
    }
}
