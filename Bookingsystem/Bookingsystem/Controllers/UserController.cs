using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;

namespace Bookingsystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpPost]
        public ActionResult Register( string name,string address,string password) {

            SqlConnection sql = new SqlConnection("Data Source=DESKTOP-L28GF4F\\SQLEXPRESS;Initial Catalog=bookingSystem;Integrated Security=True");


            sql.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = $"insert into Users values(1,'{name}','{address}','{password}',null)";
            cmd.Connection = sql;
           cmd.ExecuteNonQuery();

            sql.Close();

            return Ok();
        
        }



    }
}
