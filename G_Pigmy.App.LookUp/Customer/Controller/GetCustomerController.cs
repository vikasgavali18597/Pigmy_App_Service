using G_Pigmy.App.LookUp.Customer.Queries;
using G_Pigmy.App.LookUp.Customer.Response;
using GLib.Common;
using GLib.CQRS.Query.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace G_Pigmy.App.LookUp.Customer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetCustomerController : ControllerBase
    {
        private readonly IQueryHandler<GetCustomerQuery, Response<GetCustomerResponse>> _handler;

        public GetCustomerController(IQueryHandler<GetCustomerQuery, Response<GetCustomerResponse>> handler)
        {
                _handler = handler;
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery]GetCustomerQuery query)
        {
            try
            {
                return Ok(await _handler.HandleAsync(query));
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }         
        }
    }
}
