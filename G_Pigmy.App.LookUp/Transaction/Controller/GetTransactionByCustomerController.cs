using G_Pigmy.App.LookUp.Transaction.Query;
using G_Pigmy.App.LookUp.Transaction.Response;
using GLib.Common;
using GLib.CQRS.Query.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace G_Pigmy.App.LookUp.Transaction.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetTransactionByCustomerController : ControllerBase
    {
        private readonly IQueryHandler<TransactionQueryOnCustomer, Response<IEnumerable<GetTransactionByCustomerResponse>>> _handler;
        public GetTransactionByCustomerController(IQueryHandler<TransactionQueryOnCustomer, Response<IEnumerable<GetTransactionByCustomerResponse>>> handler)
        {
             _handler = handler;
        }


        [HttpGet]
        public async Task<IActionResult> GetTransactionAsync([FromQuery] TransactionQueryOnCustomer query)
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
