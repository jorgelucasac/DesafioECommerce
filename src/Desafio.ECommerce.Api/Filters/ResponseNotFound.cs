using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.ECommerce.Api.Filters
{
    public class ResponseNotFound : ProducesResponseTypeAttribute
    {
        public ResponseNotFound() : base(typeof(string), StatusCodes.Status404NotFound)
        {
        }
    }
}