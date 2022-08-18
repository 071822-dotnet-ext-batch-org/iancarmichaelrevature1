using Models;
using System.Data.SqlClient;

namespace RepositoryLayer
{
    public class RepoLayer
    {
        public async Task<List<Ticket>> GetStatusAsync(string approval)
        {
            SqlConnection conn = new SqlConnection("Server=tcp:ilcarmichaelrevature.database.windows.net,1433;Initial Catalog=ProjectOne;Persist Security Info=False;User ID=ilcarmichael;Password=Idontusethisforanythingelse1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Tickets WHERE approvalStatus = @approval", conn))
            {
                command.Parameters.AddWithValue("@approval", approval);
                conn.Open();
                SqlDataReader? ret = await command.ExecuteReaderAsync();
                List<Ticket> tList = new List<Ticket>();
                while (ret.Read())
                {
                    Ticket t = new Ticket((Guid)ret[0], (Guid)ret[1], ret.GetString(2), ret.GetDecimal(3), ret.GetString(4));
                    tList.Add(t);
                }
                conn.Close();
                return tList;
            }
        }

        public Task<Ticket> UpdateStatusAsync(ApprovalDto approval)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsMangerAsync(Guid employeeId)
        {
            SqlConnection conn = new SqlConnection("Server=tcp:ilcarmichaelrevature.database.windows.net,1433;Initial Catalog=ProjectOne;Persist Security Info=False;User ID=ilcarmichael;Password=Idontusethisforanythingelse1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT isManager FROM Employee WHERE employeeId = @id", conn))
            {
                command.Parameters.AddWithValue("@id", employeeId);
                conn.Open();
                SqlDataReader? ret = await command.ExecuteReaderAsync();
                if (ret.Read() && ret.GetBoolean(0))
                    {
                        conn.Close();
                        return true;
                    }
                }
                conn.Close();
                return false;
            }
        }
    }
