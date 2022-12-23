using System.Text;
using System.Text.Json;
using Serilog;
using CurrencyExchange.Api.Common.Models;

namespace CurrencyExchange.Api.Middleware
{
    public class RequestResponseLogMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestResponseLogMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            var request = await FormatRequest(context.Request);
            Log.Information(JsonSerializer.Serialize(request));

            var originalBodyStream = context.Response.Body;

            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;

                await _next(context);

                var response = await FormatResponse(context.Response);

                Log.Information(JsonSerializer.Serialize(response));

                await responseBody.CopyToAsync(originalBodyStream);
            }
        }

        private async Task<LogModel> FormatRequest(HttpRequest request)
        {
            request.EnableBuffering();

            var buffer = new byte[Convert.ToInt32(request.ContentLength)];

            await request.Body.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false);

            var bodyAsText = Encoding.UTF8.GetString(buffer);

            request.Body.Position = 0;

            return new LogModel
            {
                Scheme = request.Scheme,
                Host = request.Host.ToString(),
                Path = request.Path,
                QueryString = request.QueryString.ToString(),
                RequestBody = bodyAsText,
            };
        }

        private async Task<LogModel> FormatResponse(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);

            string text = await new StreamReader(response.Body).ReadToEndAsync();

            response.Body.Seek(0, SeekOrigin.Begin);

            return new LogModel
            {
                StatusCode = response.StatusCode,
                ResponseBody = text
            };
        }
    }

}
