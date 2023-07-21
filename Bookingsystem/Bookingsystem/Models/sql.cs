using System.Data;
using System.Data.SqlClient;

namespace Bookingsystem.Models
{
    public class sql
    {
        string connectionString= "Data Source=DESKTOP-L28GF4F\\SQLEXPRESS;Initial Catalog = bookingSystem; Integrated Security = True";
        SqlConnection SqlConnection;

        SqlCommand Command;

        public sql() {

        
            SqlConnection=new SqlConnection(connectionString);
            Command = new SqlCommand(connectionString);

        
        }

        public void open() {

            SqlConnection.Open();
        }



        public bool insert(string query) { 
          
           Command.CommandText=query;
            Command.Connection=SqlConnection;

           int result= Command.ExecuteNonQuery();

            if (result != 0)
                return true;
            else
                return false;
        
        }

        public DataTable GetRows(string query) { 
        
            DataTable dt=new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query,SqlConnection);

            adapter.Fill(dt);

            return dt;
        
        }

        public void close()
        {

            SqlConnection.Close();

        }

    }
}
