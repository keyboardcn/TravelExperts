using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class AgentsDB
    {
        //get Agent 
        //check if login is successfull
        //return agent ID if exist, otherwise, return -1
        //[DataObjectMethod(DataObjectMethodType.Select)]
        public static int getAgent(string f, string l)
        {
            int id = -1; //default to negative value


            string sql = "SELECT AgentId " +
                "FROM Agents " + "WHERE AgentId = @id AND AgtPassword = @password";

            //string sql = "SELECT ID " + "FROM Customer " + "WHERE FirstName = @firstName";

            SqlConnection connection = TravelExpertsDB.GetConnection();

            SqlCommand cmd = new SqlCommand(sql, connection);

            int agentid = Convert.ToInt32(f);

            cmd.Parameters.AddWithValue("@id", agentid);
            cmd.Parameters.AddWithValue("@password", l);


            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);

                // build customer object to return
                if (reader.Read()) // if there is a customer with this ID
                {
                    Agent agt = new Agent();
                    //fill data from reader
                    agt.AgentId = (int)reader["AgentId"];
                    id = agt.AgentId;
                    //cust.Name = reader["Name"].ToString();
                    //cust.Address = reader["Address"].ToString();
                    //cust.City = reader["City"].ToString();
                    //cust.State = reader["State"].ToString();
                    //cust.ZipCode = reader["ZipCode"].ToString();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return id;
        }
    }

}

