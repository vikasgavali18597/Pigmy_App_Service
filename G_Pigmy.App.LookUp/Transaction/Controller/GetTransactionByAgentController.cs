using G_Pigmy.App.LookUp.Transaction.Query;
using G_Pigmy.App.LookUp.Transaction.Response;
using GLib.CQRS.Query.Abstractions;
using GLib.Common;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using System.Net;

namespace G_Pigmy.App.LookUp.Transaction.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetTransactionByAgentController : ControllerBase
    {
        private readonly IQueryHandler<TransactionQueryOnAgent, Response<IEnumerable<TransactionResponse>>> _handler;

        public GetTransactionByAgentController(IQueryHandler<TransactionQueryOnAgent, Response<IEnumerable<TransactionResponse>>> handler)
        {
            _handler = handler;
        }

        [HttpGet]
        public async Task<IActionResult> GetTransactions([FromQuery]TransactionQueryOnAgent query)
        {
            try
            {
                return Ok(await _handler.HandleAsync(query));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
