using Models;
using RepositoryLayer;

namespace BusinessLayer
{
    public class BizLayer
    {
        private readonly RepoLayer _repoLayer;

        public BizLayer()
        {
            this._repoLayer = new RepoLayer();
        }

        public async Task<List<Ticket>> GetStatusAsync(string approval)
        {
            List<Ticket> list = await this._repoLayer.GetStatusAsync(approval);
            return list;
        }

        public async Task<Ticket> UpdateStatusAsync(ApprovalDto approval)
        {
            if (await this._repoLayer.IsMangerAsync(approval.employeeId))
            {
                Ticket approvedTicket = await this._repoLayer.UpdateStatusAsync(approval);
                return approvedTicket;
            }
            else return null;
        }
    }
}