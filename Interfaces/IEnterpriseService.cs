using PostgresEFCore.Dto;
using PostgresEFCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostgresEFCore.Interfaces
{
    public interface IEnterpriseService
    {
        public List<EnterpriseDto> GetEnterprises();
        public EnterpriseDto GetEnterpriseByNit(long nit);
        public EnterpriseDto GetEnterpriseByIdCode(int idCode);
        public Task<string> UpdateEnterprise(Enterprise enterprise);
    }
}
