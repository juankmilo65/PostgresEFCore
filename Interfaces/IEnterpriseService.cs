using PostgresEFCore.Dto;
using PostgresEFCore.Models;
using System.Collections.Generic;

namespace PostgresEFCore.Interfaces
{
    public interface IEnterpriseService
    {
        public List<EnterpriseDto> GetEnterprises();
        public EnterpriseDto GetEnterpriseByNit(long nit);
        public Enterprise GetEnterpriseByIdCode(int idCode);
    }
}
