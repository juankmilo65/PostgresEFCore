using PostgresEFCore.Interfaces;
using PostgresEFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostgresEFCore.Services
{
    public class EnterpriseService : IEnterpriseService
    {
        public Enterprise GetEnterpriseByIdCode(int idCode)
        {
            throw new NotImplementedException();
        }

        public Enterprise GetEnterpriseByNitAndAsociatedCodes(long nit, List<int> idsCode)
        {
            throw new NotImplementedException();
        }

        public List<Enterprise> GetEnterprises()
        {
            throw new NotImplementedException();
        }
    }
}
