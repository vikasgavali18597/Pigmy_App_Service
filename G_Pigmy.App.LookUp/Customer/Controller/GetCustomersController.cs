using G_Pigmy.App.LookUp.Customer.Queries;
using G_Pigmy.App.LookUp.Customer.Response;
using GLib.Common;
using GLib.CQRS.Query.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace G_Pigmy.App.LookUp.Customer.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class GetCustomersController : ControllerBase
    {
        private readonly IQueryHandler<GetCustomersQuery, Response<IEnumerable<GetCustomerResponse>>> _handler;

        public GetCustomersController(IQueryHandler<GetCustomersQuery, Response<IEnumerable<GetCustomerResponse>>> handler)
        {
            _handler = handler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers([FromQuery]GetCustomersQuery query)
        {
            try
            {
                return Ok( await _handler.HandleAsync(query));
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
