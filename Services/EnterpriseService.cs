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

        public async Task<string> UpdateEnterprise(Enterprise enterprise)
        {

            var enter = _context.Codes.Where(o => o.Owner.Id.Equals(enterprise.Id));

            foreach (var item in enter)
            {
                item.Owner.Name = enterprise.Name;
                item.Owner.Nit = enterprise.Nit;
                item.Owner.GIn = enterprise.GIn;

                _context.Enterprises.Update(item.Owner);
            }

            try
            {
                await _context.SaveChangesAsync();
                return "Updated";
            }
            catch (Exception ex)
            {

                if (GetEnterprisesBase(null, null, enterprise.Id) == null)
                {
                    return "Not Found";
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }


        }

        public EnterpriseDto GetEnterpriseByIdCode(int idCode)
        {
            return GetEnterprisesBase(null, idCode, null).First();
        }

        public EnterpriseDto GetEnterpriseByNit(long nit)
        {
            return GetEnterprisesBase(nit, null, null).First();
        }

        public List<EnterpriseDto> GetEnterprises()
        {
            return GetEnterprisesBase(null, null, null);
        }


        private List<EnterpriseDto> GetEnterprisesBase(long? nit, int? idCod, int? idEnterprise)
        {
            List<EnterpriseDto> enterprisesDto = new List<EnterpriseDto>();
            List<EnterpriseDto> enterprisesDtoAux = new List<EnterpriseDto>();
            EnterpriseDto enterpriseDto = new EnterpriseDto();
            var codes = nit == null && idCod == null && idEnterprise == null ? _context.Codes :
                nit != null && idCod == null && idEnterprise == null ? _context.Codes.Where(o => o.Owner.Nit.Equals(nit)) :
                nit == null && idCod == null && idEnterprise != null ? _context.Codes.Where(o => o.Owner.Id.Equals(idEnterprise)) :
                _context.Codes.Where(o => o.Id.Equals(idCod));


            //nit == null && idCod == null ? _context.Codes :
            //    nit != null && idCod == null ? _context.Codes.Where(o => o.Owner.Nit.Equals(nit)) :
            //    _context.Codes.Where(o => o.Id.Equals(idCod));

            foreach (var item in codes)
            {
                enterpriseDto.Id = item.Owner.Id;
                enterpriseDto.Name = item.Owner.Name;
                enterpriseDto.Nit = item.Owner.Nit;
                enterpriseDto.GIn = item.Owner.GIn;
                enterpriseDto.CodeList = new List<CodeDto>();

                if ((nit != null && idCod == null) || idEnterprise != null)
                {
                    enterpriseDto.CodeList.Add(new CodeDto
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Description = item.Description
                    });
                }


                if (!enterprisesDto.Contains(enterpriseDto))
                {
                    enterprisesDto.Add(enterpriseDto);
                }
                enterpriseDto = new EnterpriseDto();
            }


            foreach (var ente in enterprisesDto)
            {
                if (enterprisesDtoAux.Count > 0 && (nit != null && idCod == null) || idEnterprise != null)
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
