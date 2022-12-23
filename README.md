# Currency Exchange

Before running the project you need to make docker-compose up which is placed in root folder of project. 


#### Third-party libraries used in the project:
- AspNetCoreRateLimit
- Mapster
- Newtonsoft
- Serilog
- MediatR
- JwtBearer
- StackExchangeRedis
- ElasticSearch
- Kibana

#### Structure of the project:
<img src="Readme/Structure.jpg" alt="drawing" width="200"/>
<img src="Readme/Structure1.jpg" alt="drawing" width="400"/>

#### Problem:

- Integrating to a rate provider to obtain the latest currency exchange rates.
  - For getting currency exchange rates, I used the latest API of Fixter.
- Retaining information about currency exchange trades carried out by its clients
  - User must register and login in order to create a JWT token before sending a request for a currency exchange.
  - After including the token in the header and sending the currency exchange request, I first check the cache with the key as the base currency. If it's in the cache, I'll get it and use it, but if it's not, I'll call the fixer API, save the response in the cache, and then perform the remaining operations.
- When an exchange rate is used it should never be older than 30 minutes (Bonus question)
  - For this purpose, I used TTL with a value of 30 minutes in redis cache.
- Limiting each client to 10 currency exchange trades per hour (Bonus question)
  - To deal with this requirement, I used the AspNetCoreRateLimit library. For now, I check the jwt of the token to specify a limited number of requests, but we can use userId instead of jwt in the defined middleware.