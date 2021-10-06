using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.ECommerce.Api.Filters
{
    public class ResponseUnauthorized : ProducesResponseTypeAttribute
    {
        public ResponseUnauthorized() : base(typeof(ValidationProblemDetails), StatusCodes.Status401Unauthorized)
        {
        }
    }
}