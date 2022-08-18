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

    public async Task<bool> IsManagerAsync(Guid employeeId)
    {
        SqlConnection conn = new SqlConnection("Server=tcp:ilcarmichaelrevature.database.windows.net,1433;Initial Catalog=ProjectOne;Persist Security Info=False;User ID=ilcarmichael;Password=Idontusethisforanythingelse1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        using (SqlCommand cmd = new SqlCommand($"SELECT isManager FROM Employees WHERE employeeId = @id", conn))
        {
            cmd.Parameters.AddWithValue("@id", employeeId); // this format protects against SQL Injection!!
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
            cmd.Parameters.AddWithValue("@status", status); // this format protects against SQL Injection!!
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

    /*    public async Task<Ticket> UpdateStatusAsync(Guid ticketId, string approvalStatus)
        {
            SqlConnection conn = new SqlConnection("Server=tcp:ilcarmichaelrevature.database.windows.net,1433;Initial Catalog=ProjectOne;Persist Security Info=False;User ID=ilcarmichael;Password=Idontusethisforanythingelse1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand cmd = new SqlCommand($"UPDATE Ticket Set approvalStatus = @approvalStatus WHERE ticketId = @ticketId", conn))
            {
                cmd.Parameters.AddWithValue("@ticketId", ticketId); // this format protects against SQL Injection!!
                cmd.Parameters.AddWithValue("@approvalStatus", approvalStatus);
                conn.Open();

            }
        }
    */
}