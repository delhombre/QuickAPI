using System.Data.SqlClient;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using QuickAPI.API.Models;

namespace QuickAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly string _connectionString =
            "Server=tcp:servereastus2.database.windows.net,1433;Initial Catalog=devops;Persist Security Info=False;User ID=adminuser;Password=123456a.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        [HttpGet]
        public IActionResult GetAll()
        {
            using SqlConnection connection = new(_connectionString);
            SqlCommand command = connection.CreateCommand();
            IEnumerable<Student> students = connection.Query<Student>("SELECT * FROM Student");
            return Ok(students);
        }
    }
}
