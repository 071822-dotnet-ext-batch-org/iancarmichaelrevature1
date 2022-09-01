using Models;
using RepositoryLayer;

namespace BusinessLayer;
public class BizLayer
{
    private readonly RepoLayer _repoLayer;
    public BizLayer()
    {
        this._repoLayer = new RepoLayer();
    }
    public async Task<List<Ticket>> GetStatusAsync(string status)
    {
        List<Ticket> list = await this._repoLayer.GetStatusAsync(status);
        return list;
    }

    public async Task<UpdatedTicketDto> UpdateStatusAsync(ApprovalDto approvalDto)
    {
        if (await this._repoLayer.IsManagerAsync(approvalDto.employeeId))
        {
            UpdatedTicketDto approvedTicket = await this._repoLayer.UpdateStatusAsync(approvalDto.ticketId, approvalDto.approvalStatus);
            return approvedTicket;
        }
        else return null;
    }

    public async Task<LoginDto> LoginAsync(LoginDto login)
    {
        // the repository layer will validate the login info
        LoginDto loginDto = await this._repoLayer.LoginAsync(login);
        return loginDto;
    }

    public async Task<Ticket> CreateTicketAsync(Ticket ticket)
    {
        Ticket newTicket = await this._repoLayer.CreateTicketAsync(ticket);
        return newTicket;
    }
}