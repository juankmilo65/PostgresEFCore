using PostgresEFCore.Models;
using System.Collections.Generic;

namespace PostgresEFCore.Interfaces
{
    public interface ICodeService
    {
        public List<Code> GetCodesByEnterpriseId(int id);
    }
}
