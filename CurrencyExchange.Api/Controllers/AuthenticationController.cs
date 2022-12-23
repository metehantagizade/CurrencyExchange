using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CurrencyExchange.Application.Authentication.Commands.Register;
using CurrencyExchange.Application.Authentication.Common;
using CurrencyExchange.Application.Authentication.Queries.Login;
using CurrencyExchange.Contracts.Authentication;

namespace CurrencyExchange.Api.Controllers;

[Route("auth")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuthenticationController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
        var command = _mapper.Map<RegisterCommand>(registerRequest);
        AuthenticationResult authResult = await _mediator.Send(command);

        var response = _mapper.Map<AuthenticationResponse>(authResult);

        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
        var query = _mapper.Map<LoginQuery>(loginRequest);
        var authResult = await _mediator.Send(query);

        var response = _mapper.Map<AuthenticationResponse>(authResult);

        return Ok(response);
    }

}


