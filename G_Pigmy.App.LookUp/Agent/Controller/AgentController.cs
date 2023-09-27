using G_Pigmy.App.LookUp.Agent.Query;
using G_Pigmy.App.LookUp.Agent.Response;
using GLib.Common;
using GLib.CQRS.Query.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace G_Pigmy.App.LookUp.Agent.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly IQueryHandler<GetAgentQuery, Response<GetAgentResponse>> _handler;
        public AgentController(AbstractQueryHandler<GetAgentQuery, Response<GetAgentResponse>> handler)
        {
            _handler = handler; 
        }

        [HttpGet]
        public async Task<IActionResult> GetAgentById([FromQuery]GetAgentQuery query)
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
