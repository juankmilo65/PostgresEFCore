using PostgresEFCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostgresEFCore.Interfaces
{
    public interface ICodeService
    {
        public List<Code> GetCodesByEnterpriseId(int id);
        public Task<string> UpdateCode(Code code);
    }
}
