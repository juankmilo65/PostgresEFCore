using Microsoft.EntityFrameworkCore;
using PostgresEFCore.Data;
using PostgresEFCore.Interfaces;
using PostgresEFCore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostgresEFCore.Services
{
    public class CodeService : ICodeService
    {
        private DataContext _context = null;
        public CodeService(DataContext contex)
        {
            _context = contex;
        }

        public List<Code> GetCodesByEnterpriseId(int id)
        {
            return _context.Codes.Where(o => o.Owner.Id.Equals(id)).ToList();
        }

        public Code GetCodeById(int id)
        {
            return _context.Codes.Where(o => o.Id.Equals(id)).First();
        }

        public async Task<string> UpdateCode(Code code)
        {
            _context.Entry(code).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return "Updated";
            }
            catch (DbUpdateConcurrencyException)
            {

                if (GetCodeById(code.Id) == null)
                {
                    return "Not Found";
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
