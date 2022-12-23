using System.Text.Json;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using CurrencyExchange.Application.Common.Interfaces.Persistence;
using CurrencyExchange.Application.Common.Interfaces.Services;
using CurrencyExchange.Application.CurrencyExchange.Common;
using CurrencyExchange.Domain.Entities;
using CurrencyExchange.Domain.FixerModel;

namespace CurrencyExchange.Application.CurrencyExchange.Commands.Exchange;

public class ExchangeCommandHandler : IRequestHandler<ExchangeCommand, ExchangeResult>
{
    private readonly IFixerCurrencyProvider _fixerCurrencyProvider;
    private readonly ICacheRepository _cacheRepository;
    private readonly IUserCurrencyExchangesRepository _userCurrencyExchangesRepository;
    private readonly IMapper _mapper;

    public ExchangeCommandHandler(IFixerCurrencyProvider fixerCurrencyProvider, IDistributedCache cache, ICacheRepository cacheRepository, IUserCurrencyExchangesRepository userCurrencyExchangesRepository, IMapper mapper)
    {
        _fixerCurrencyProvider = fixerCurrencyProvider;
        _cacheRepository = cacheRepository;
        _userCurrencyExchangesRepository = userCurrencyExchangesRepository;
        _mapper = mapper;
    }
    public async Task<ExchangeResult> Handle(ExchangeCommand request, CancellationToken cancellationToken)
    {
        // Check from redis if does not exist call api
        LatestResponse fixerLatestResponse = await _cacheRepository.GetRecordAsync<LatestResponse>(request.From);
        if (fixerLatestResponse == null)
        {
            var response = _fixerCurrencyProvider.GetLatest(request.From);
            fixerLatestResponse = JsonSerializer.Deserialize<LatestResponse>(response);
            await _cacheRepository.SetRecordAsync(request.From, fixerLatestResponse);
        }

        var currencyValue = fixerLatestResponse.rates.FirstOrDefault(w => w.Key == request.To);
        var totalCurrency = currencyValue.Value * request.Count;
        ExchangeResult result = new ExchangeResult
        {
            Count = request.Count,
            From = request.From,
            To = request.To,
            Rate = currencyValue.Value,
            Result = totalCurrency,
            UserId = request.UserId,
        };

        _userCurrencyExchangesRepository.Add(_mapper.Map<UserCurrencyExchanges>(result));
        return result;
    }
}