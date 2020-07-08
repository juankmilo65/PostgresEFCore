using PostgresEFCore.Data;
using PostgresEFCore.Interfaces;
using PostgresEFCore.Models;
using System;
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
    }
}
