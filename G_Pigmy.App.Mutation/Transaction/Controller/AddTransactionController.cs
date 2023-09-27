using G_Pigmy.App.Mutation.Transaction.Command;
using GLib.Common;
using GLib.CQRS.Command.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace G_Pigmy.App.Mutation.Transaction.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddTransactionController : ControllerBase
    {
        private readonly ICommandHandler<TransactionCommand, Response> _handler;
        public AddTransactionController(ICommandHandler<TransactionCommand, Response> handler)
        {
             _handler = handler;
        }


        [HttpPost]
        public async Task<IActionResult> AddTransaction([FromQuery] TransactionCommand command)
        {
            try
            {
                return Ok(await _handler.HandleAsync(command));
            }
            catch(Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
