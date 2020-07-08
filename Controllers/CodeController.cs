using Microsoft.AspNetCore.Mvc;
using PostgresEFCore.Data;
using PostgresEFCore.Interfaces;
using System.Linq;

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

        [HttpGet("/api/getCodesByEnterpriseId/{id}")]
        public ActionResult GetCodesByEnterpriseId(int id)
        {
            return Ok(_service.GetCodesByEnterpriseId(id));
        }
    }
}
