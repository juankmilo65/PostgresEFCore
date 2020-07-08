using Microsoft.EntityFrameworkCore;
using PostgresEFCore.Data;
using PostgresEFCore.Dto;
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
        private DataContext _context = null;
        public EnterpriseService(DataContext contex)
        {
            _context = contex;
        }

        public Enterprise GetEnterpriseByIdCode(int idCode)
        {
            throw new NotImplementedException();
        }

        public EnterpriseDto GetEnterpriseByNit(long nit)
        {
            return GetEnterprisesBase(nit).First();
        }

        public List<EnterpriseDto> GetEnterprises()
        {
            return GetEnterprisesBase(null);
        }


        private List<EnterpriseDto> GetEnterprisesBase(long? nit)
        {
            List<EnterpriseDto> enterprisesDto = new List<EnterpriseDto>();
            List<EnterpriseDto> enterprisesDtoAux = new List<EnterpriseDto>();
            EnterpriseDto enterpriseDto = new EnterpriseDto();
            var codes = nit == null ? _context.Codes : _context.Codes.Where(o => o.Owner.Nit.Equals(nit));

            foreach (var item in codes)
            {
                enterpriseDto.Id = item.Owner.Id;
                enterpriseDto.Name = item.Owner.Name;
                enterpriseDto.Nit = item.Owner.Nit;
                enterpriseDto.GIn = item.Owner.GIn;
                enterpriseDto.CodeList = new List<CodeDto>();
                enterpriseDto.CodeList.Add(new CodeDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description
                });

                if (!enterprisesDto.Contains(enterpriseDto))
                {
                    enterprisesDto.Add(enterpriseDto);
                }
                enterpriseDto = new EnterpriseDto();
            }


            foreach (var ente in enterprisesDto)
            {
                if (enterprisesDtoAux.Count > 0)
                {
                    bool aux = enterprisesDtoAux.Select(o => o.Id.Equals(ente.Id)).First();
                    if (aux)
                    {
                        enterprisesDtoAux.Where(o => o.Id.Equals(ente.Id)).First().CodeList.AddRange(ente.CodeList);
                    }
                    else
                    { enterprisesDtoAux.Add(ente); }
                }
                else
                {
                    enterprisesDtoAux.Add(ente);
                }
            }


            return enterprisesDtoAux;
        }
    }
}
