using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostgresEFCore.Dto
{
    public class EnterpriseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Nit { get; set; }
        public long GIn { get; set; }
        public List<CodeDto> CodeList { get; set; }
    }
}
