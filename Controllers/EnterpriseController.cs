using Microsoft.AspNetCore.Mvc;
using PostgresEFCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostgresEFCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnterpriseController : ControllerBase
    {
        private IEnterpriseService _service;

        public EnterpriseController(IEnterpriseService service)
        {
            _service = service;
        }

        [HttpGet("/api/getEnterprises/{nit}")]
        public ActionResult GetEnterprisesByNit(long nit)
        {
            return Ok(_service.GetEnterpriseByNit(nit));
        }

        [HttpGet("/api/getEnterprises")]
        public ActionResult GetEnterprises()
        {
            return Ok(_service.GetEnterprises());
        }
    }
}
