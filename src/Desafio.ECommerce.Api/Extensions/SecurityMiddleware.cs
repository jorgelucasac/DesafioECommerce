using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Desafio.ECommerce.Api.Extensions
{
    public class SecurityMiddleware
    {
        private readonly RequestDelegate _next;
        private AppSettings _appSettings;

        public SecurityMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;

            if (PossuiAcesso(context))
                await _next(context);
            else
                await AcessoNegado(context);
        }

        private bool PossuiAcesso(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            return token == _appSettings.Token;
        }

        private async Task AcessoNegado(HttpContext context)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = StatusCodes.Status401Unauthorized;
            await response.WriteAsJsonAsync(new ValidationProblemDetails(new Dictionary<string, string[]>())
            {
                Title = "Não autorizado"
            });
        }

    }
}