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


        // logs in the user asynchronously with a httppost request
        [HttpPost("LoginUserAsync")]
        public async Task<ActionResult> LoginUserAsync(LoginDto login)
        {
            if (ModelState.IsValid)
            {
            LoginDto loginDto = await this._businessLayer.LoginAsync(login);
            return Ok(loginDto);
            }
            return null;
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
        public async Task<ActionResult<UpdatedTicketDto>> UpdateStatusAsync(ApprovalDto approval)
        {
            if (ModelState.IsValid)
            {
                //send the DTO to BusinessLayer
                UpdatedTicketDto approvedTicket = await this._businessLayer.UpdateStatusAsync(approval);
                return approvedTicket;
            }
            else return Conflict(approval);
        }
        
    }
}


