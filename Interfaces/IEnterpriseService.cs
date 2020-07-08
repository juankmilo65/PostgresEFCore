using PostgresEFCore.Models;
using System.Collections.Generic;

namespace PostgresEFCore.Interfaces
{
    public interface IEnterpriseService
    {
        public List<Enterprise> GetEnterprises();
        public Enterprise GetEnterpriseByNitAndAsociatedCodes(long nit, List<int> idsCode);
        public Enterprise GetEnterpriseByIdCode(int idCode);
    }
}
