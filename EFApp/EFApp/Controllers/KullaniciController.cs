using EFApp;
using EFApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace DapperApp.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class KullaniciController : ControllerBase
    {
        [HttpGet()]
        public ActionResult<IEnumerable<Kullanici>> Get()
        {
            using (var ct = new EFContext())
            {
              var kullanicis=  ct.Kullanicis.ToList();
                return new ActionResult<IEnumerable<Kullanici>>(kullanicis);
            }
        
        }
    }
}
