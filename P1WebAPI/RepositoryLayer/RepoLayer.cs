using Models;
using System.Data.SqlClient;

namespace RepositoryLayer;
public class RepoLayer
{
    public async Task<List<Ticket>> GetStatusAsync(string status)
    {
        SqlConnection conn = new SqlConnection("Server=tcp:ilcarmichaelrevature.database.windows.net,1433;Initial Catalog=ProjectOne;Persist Security Info=False;User ID=ilcarmichael;Password=Idontusethisforanythingelse1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        using (SqlCommand cmd = new SqlCommand($"SELECT * FROM Ticket WHERE approvalStatus = @status", conn))
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
        using (SqlCommand cmd = new SqlCommand($"SELECT isManager FROM Employee WHERE employeeId = @id", conn))
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

    public Task<Ticket> UpdateStatusAsync(ApprovalDto approval)
    {
        throw new NotImplementedException();
    }
}