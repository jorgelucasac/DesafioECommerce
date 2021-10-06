using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.ECommerce.Api.Filters
{
    public class ResponseInternalServerError : ProducesResponseTypeAttribute
    {
        public ResponseInternalServerError() : base(typeof(ValidationProblemDetails), StatusCodes.Status500InternalServerError)
        {
        }
    }
}