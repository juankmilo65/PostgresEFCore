using Microsoft.AspNetCore.Mvc;
using PostgresEFCore.Interfaces;
using PostgresEFCore.Models;
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

        [HttpPut("/api/updateEnterprise/{id}")]
        public async Task<ActionResult> UpdateEnterprise(int id, Enterprise enterprise)
        {
            if (id != enterprise.Id)
            {
                return BadRequest();
            }

            string result = await _service.UpdateEnterprise(enterprise);

            if (result == "Not Found")
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpGet("/api/getEnterpriseByIdCode/{idCode}")]
        public ActionResult GetEnterpriseByIdCode(int idCode)
        {
            return Ok(_service.GetEnterpriseByIdCode(idCode));
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
