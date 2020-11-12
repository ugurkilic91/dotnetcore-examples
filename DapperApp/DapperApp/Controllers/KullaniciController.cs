using Dapper;
using DapperApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SQLite;

namespace DapperApp.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class KullaniciController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private string conStr;
        public KullaniciController(IConfiguration configuration)
        {
            _configuration = configuration;
            conStr = _configuration.GetConnectionString("DapperAppConStr");
        }
        [HttpGet()]
        public ActionResult<IEnumerable<Kullanici>> Get()
        {
            IEnumerable<Kullanici> firms = new List<Kullanici>();
            using (var conn = new SQLiteConnection(conStr))
            {
                conn.Open();
                firms = conn.Query<Kullanici>("SELECT * FROM KULLANICI");
             
            }
            return new ActionResult<IEnumerable<Kullanici>>(firms);
        }
    }
}
