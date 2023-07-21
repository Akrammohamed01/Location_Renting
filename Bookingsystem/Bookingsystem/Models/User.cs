using System.Data;
using static System.Net.Mime.MediaTypeNames;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace Bookingsystem.Models
{
    public class User
    {
       public int userId;
       public string fullName;
       public string email;

       public string password;

       public string photo;


        public User() {
        }
        public void  AddNewUser() {


            GetNewUserId();

            sql Sql = new sql();

            Sql.open();
           string query= $"insert into Users values({userId},'{fullName}','{email}','{password}','{photo}')";

           Sql.insert(query);

            Sql.close();


        }
        public bool CheckEmailExists(string Email) {

            sql Sql = new sql();

            Sql.open();


            string query = $"select * from Users where email='{Email}'";

           DataTable dt= Sql.GetRows(query);

            Sql.close();
            if (dt.Rows.Count != 0)
                return true;
            else 
                return false;
                  
        
        }

        private void GetNewUserId() {

            string query = "select MAX(userId) from Users";

            sql Sql = new sql();

            Sql.open();

            DataTable dt = Sql.GetRows(query);
            if (dt.Rows[0][0]!=null)
            userId =  int.Parse(dt.Rows[0][0].ToString())+1;
            else 
                userId = 1;

            Sql.close();
           
        }

        public bool CheckUserExists() {

            string query = @$"select * from Users where email='{email}' and password='{password}'";

            sql sqlObject = new sql();

            sqlObject.open();
             DataTable dt= sqlObject.GetRows(query);

            if (dt.Rows.Count != 0) {


                userId = int.Parse(dt.Rows[0]["userId"].ToString());
                fullName= dt.Rows[0]["fullName"].ToString();
                email = dt.Rows[0]["email"].ToString();
                password = dt.Rows[0]["password"].ToString();
                photo = dt.Rows[0]["photo"].ToString();

                return true;

            }
            else
                return false;
        
        }


    }
}
