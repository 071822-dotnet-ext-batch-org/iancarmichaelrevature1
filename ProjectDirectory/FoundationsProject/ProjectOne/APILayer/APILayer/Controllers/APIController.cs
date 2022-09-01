using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using BusinessLayer;

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

        /// <summary>
        /// Get the 'pending' approvalStatus(es)
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetStatusAsync")]
        [HttpGet("GetStatusAsync/{approval}")]
        public async Task<ActionResult<List<Ticket>>> GetStatusAsync(string approval, Guid? id)
        {
            List<Ticket> ticketList = await this._businessLayer.GetStatusAsync(approval);
                return Ok(ticketList);
                //return null;
        }

        [HttpPut("UpdateStatusAsync")]
        public async Task<ActionResult<Ticket>> UpdateStatusAsync(ApprovalDto approval)
        {
            //send the approvalDta to the business layer
            Ticket approvedTicket = await this._businessLayer.UpdateStatusAsync(approval);
        }
        }
    }

