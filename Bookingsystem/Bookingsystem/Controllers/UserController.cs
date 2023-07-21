using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using Bookingsystem.Models;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Bookingsystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpPost]

        [Route("Register")]
        public ActionResult Register(string name, string email, string password, IFormFile image = null) {



            User user = new User();
            user.fullName = name;
            user.email = email;
            user.password = password;


            if (user.CheckEmailExists(email)) {

                return BadRequest("Registered Email");
            }

            string workingDirectory = Environment.CurrentDirectory;

            if (!Directory.Exists(workingDirectory + '\\' + "Photos"))
                Directory.CreateDirectory(workingDirectory + '\\' + "Photos");


            if (image != null) {

                Directory.CreateDirectory(workingDirectory + '\\' + "Photos" + $"\\{name}");

                image.CopyToAsync(new FileStream(workingDirectory + '\\' + "Photos" + $"\\{name}" + $"\\{image.FileName}", FileMode.Create));

                user.photo = workingDirectory + '\\' + "Photos" + $"\\{name}" + $"\\{image.FileName}";

            }


            user.AddNewUser();
            return Ok("Registered");

        }


        [HttpGet]
        [Route("Login")]
        public ActionResult Login(string Email,string Password) {

            User user = new User();

            user.email=Email;

            user.password=Password;

            if (user.CheckUserExists()) {
               string data= JsonConvert.SerializeObject(user);
                return Ok(data);
            }
            else {

                return BadRequest("Email Or Password is Incorrect");
            }
        }

    }
}
