using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.ECommerce.Api.Filters
{
    public class ResponseBadRequest : ProducesResponseTypeAttribute
    {
        public ResponseBadRequest() : base(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)
        {
        }
    }
}