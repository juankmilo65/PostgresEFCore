using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PostgresEFCore.Data;
using PostgresEFCore.Interfaces;
using PostgresEFCore.Models;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PostgresEFCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CodeController : ControllerBase
    {
        private ICodeService _service;

        public CodeController(ICodeService service)
        {
            _service = service;
        }

        [HttpPut("/api/updateCode/{id}")]
        public async Task<ActionResult> UpdateCode(int id, Code code)
        {
            if (id != code.Id)
            {
                return BadRequest();
            }

            string result = await _service.UpdateCode(code);

            if (result == "Not Found")
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpGet("/api/getCodesByEnterpriseId/{id}")]
        public ActionResult GetCodesByEnterpriseId(int id)
        {
            return Ok(_service.GetCodesByEnterpriseId(id));
        }
    }
}
