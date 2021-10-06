using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Desafio.ECommerce.Api.Extensions
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = StatusCodes.Status500InternalServerError;
                await response.WriteAsJsonAsync(ObterErrosResposta());
            }
        }

        private ValidationProblemDetails ObterErrosResposta()
        {
            return new ValidationProblemDetails(new Dictionary<string, string[]>())
            {
                Title = "Ocorreu um erro na sua requisição. Por favor, tente novamente!"
            };
        }
    }
}