using BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly BizLayer _businessLayer;
        public APIController()
        {
            this._businessLayer = new BizLayer();
        }

        [HttpGet("GetStatusAsync")] // get all tickets
        [HttpGet("GetStatusAsync/{status}")] // get all tickets of status
        public async Task<ActionResult<List<Ticket>>> GetStatusAsync(string status, Guid? id)
        {
            List<Ticket> ticketList = await this._businessLayer.GetStatusAsync(status);
            return Ok(ticketList); //returns 200
            //return null;
        }

        [HttpPut("UpdateStatusAsync")]
        public async Task<ActionResult<Ticket>> UpdateStatusAsync(ApprovalDto approval)
        {
            //send the DTO to BusinessLayer
            Ticket approvedTicket = await this._businessLayer.UpdateStatusAsync(approval);
            return approvedTicket;
        }
    }
}