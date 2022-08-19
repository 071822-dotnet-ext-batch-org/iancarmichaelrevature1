using Models;
using System.Data.SqlClient;

namespace RepositoryLayer;
public class RepoLayer
{
    public async Task<List<Ticket>> GetStatusAsync(string status)
    {
        SqlConnection conn = new SqlConnection("Server=tcp:ilcarmichaelrevature.database.windows.net,1433;Initial Catalog=ProjectOne;Persist Security Info=False;User ID=ilcarmichael;Password=Idontusethisforanythingelse1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        using (SqlCommand cmd = new SqlCommand($"SELECT * FROM Tickets WHERE approvalStatus = @status", conn))
        {
            cmd.Parameters.AddWithValue("@status", status); // this format protects against SQL Injection!!
            conn.Open();
            SqlDataReader? ret = await cmd.ExecuteReaderAsync();
            List<Ticket> tList = new List<Ticket>();
            while (ret.Read())
            {
                var t = new Ticket((Guid)ret[0], (Guid)ret[1], ret.GetString(2), ret.GetDecimal(3), ret.GetString(4));
                tList.Add(t);
            }
            conn.Close();
            return tList;
        }
    }

// present user with all ticket properties to be filled out
    public async Task<Ticket> CreateTicketAsync(Ticket ticket)
    {
        SqlConnection conn = new SqlConnection("Server=tcp:ilcarmichaelrevature.database.windows.net,1433;Initial Catalog=ProjectOne;Persist Security Info=False;User ID=ilcarmichael;Password=Idontusethisforanythingelse1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        using (SqlCommand cmd = new SqlCommand($"INSERT INTO Tickets (ticketId, employeeId_fk, reimbursementDescription, reimbursementAmount, approvalStatus) VALUES (@ticketId, @employeeId, @description, @cost, @status)", conn))
        {
            cmd.Parameters.AddWithValue("@ticketId", ticket.ticketId);
            cmd.Parameters.AddWithValue("@employeeId", ticket.employeeId_Fk);
            cmd.Parameters.AddWithValue("@description", ticket.reimbursementDescription);
            cmd.Parameters.AddWithValue("@cost", ticket.reimbursementAmount);
            cmd.Parameters.AddWithValue("@status", ticket.approvalStatus);
            conn.Open();
            int ret = await cmd.ExecuteNonQueryAsync();
            while (ret > 0)
            {
                return ticket;
            }
            conn.Close();
            return null;
        }
    }


    public async Task<LoginDto> LoginAsync(LoginDto login)
    {
        SqlConnection conn = new SqlConnection("Server=tcp:ilcarmichaelrevature.database.windows.net,1433;Initial Catalog=ProjectOne;Persist Security Info=False;User ID=ilcarmichael;Password=Idontusethisforanythingelse1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        using (SqlCommand cmd = new SqlCommand($"SELECT email, password FROM Employees WHERE email = @email AND password = @password", conn))
        {
            cmd.Parameters.AddWithValue("@email", login.email);
            cmd.Parameters.AddWithValue("@password", login.password);
            conn.Open();
            SqlDataReader? ret = await cmd.ExecuteReaderAsync();
            LoginDto? l = null;
            if (ret.Read())
            {
                l = new LoginDto(ret.GetString(0), ret.GetString(1));
                return l;
            }
            conn.Close();
            return null;
        }
    }


    public async Task<bool> IsManagerAsync(Guid employeeId)
    {
        SqlConnection conn = new SqlConnection("Server=tcp:ilcarmichaelrevature.database.windows.net,1433;Initial Catalog=ProjectOne;Persist Security Info=False;User ID=ilcarmichael;Password=Idontusethisforanythingelse1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        using (SqlCommand cmd = new SqlCommand($"SELECT isManager FROM Employees WHERE employeeId = @id", conn))
        {
            cmd.Parameters.AddWithValue("@id", employeeId);
            conn.Open();
            SqlDataReader? ret = await cmd.ExecuteReaderAsync();
            if (ret.Read() && ret.GetBoolean(0))
            {
                conn.Close();
                return true;
            }
            conn.Close();
            return false;
        }
    }

    public async Task<UpdatedTicketDto> UpdateStatusAsync(Guid ticketId, string status)
    {
        SqlConnection conn = new SqlConnection("Server=tcp:ilcarmichaelrevature.database.windows.net,1433;Initial Catalog=ProjectOne;Persist Security Info=False;User ID=ilcarmichael;Password=Idontusethisforanythingelse1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        using (SqlCommand cmd = new SqlCommand($"UPDATE Tickets SET approvalStatus = @status WHERE ticketId = @ticketId", conn))
        {
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@ticketId", ticketId);
            conn.Open();
            int ret = await cmd.ExecuteNonQueryAsync();
            if (ret == 1)
            {
                conn.Close();
                //call the ticketByID()
                UpdatedTicketDto utbi = await this.UpdatedTicketByIdAsync(ticketId);
                return utbi;
            }
            conn.Close();
            return null;
        }
    }

    private async Task<UpdatedTicketDto> UpdatedTicketByIdAsync(Guid ticketId)
    {
        SqlConnection conn = new SqlConnection("Server=tcp:ilcarmichaelrevature.database.windows.net,1433;Initial Catalog=ProjectOne;Persist Security Info=False;User ID=ilcarmichael;Password=Idontusethisforanythingelse1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        using (SqlCommand cmd = new SqlCommand($"SELECT ticketId, firstName, lastName, approvalStatus FROM Employees LEFT JOIN Tickets ON employeeId = employeeId_Fk WHERE ticketId = @ticketId", conn))
        {
            cmd.Parameters.AddWithValue("@ticketId", ticketId);
            conn.Open();
            SqlDataReader? ret = await cmd.ExecuteReaderAsync();
            if (ret.Read())
            {
                UpdatedTicketDto t = new UpdatedTicketDto(ret.GetGuid(0), ret.GetString(1), ret.GetString(2), ret.GetString(3));
                conn.Close();
                return t;
            }
            conn.Close();
            return null;
        }
    }
}