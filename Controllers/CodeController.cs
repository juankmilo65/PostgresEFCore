using Microsoft.AspNetCore.Mvc;
using PostgresEFCore.Data;
using System.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PostgresEFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodeController : Controller
    {
        private DataContext _context = null;
        public CodeController(DataContext contex)
        {
            _context = contex;
        }

        [HttpGet]
        public ActionResult GetCodes()
        {
            return Ok(_context.Codes.ToList());
        }
    }
}
