using MediatR;
using Microsoft.AspNetCore.Mvc;
using RequestRefund.Models.Commands;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RequestRefund.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        // POST api/<RequestsController>/create-request
        [HttpPost("create-request")]
        public async Task<ActionResult> CreateRequest([FromBody] RefundDtoCommand request)
        {
            try
            {
                await _mediator.Send(request);
                return Ok();
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
