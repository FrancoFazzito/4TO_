using ASF.Data;
using ASF.Entities;
using System;
using System.Collections.Generic;

namespace ASF.Business
{
    public class DealerBusiness
    {
        DealerDAC dealerDAC = new DealerDAC();
        CountryBusiness countryBusiness = new CountryBusiness();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id)
        {
            dealerDAC.DeleteById(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Dealer> All()
        {

            var result = dealerDAC.SelectAll();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Dealer Find(int id)
        {
            return dealerDAC.SelectById(id);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        public Dealer Save(Dealer dto)
        {

            Dealer dtoToSave;
            if (dto.Id > 0)
            {
                dtoToSave = dealerDAC.SelectById(dto.Id);
            }
            else
            {
                dtoToSave = new Dealer();
                dtoToSave.CreatedOn = DateTime.Now;
                dtoToSave.CreatedBy = dto.CreatedBy;
            }
            

            if (!String.IsNullOrEmpty(dto.FirstName)) dtoToSave.FirstName = dto.FirstName;
            if (!String.IsNullOrEmpty(dto.Description)) dtoToSave.Description = dto.Description;
            if (!String.IsNullOrEmpty(dto.LastName)) dtoToSave.LastName = dto.LastName;
            if (dto.CountryId > 0) {

                if (dto.CountryId != dtoToSave.CountryId)
                {
                    if (countryBusiness.Find(dto.CountryId) == null) throw new BusinessException("b.validation.dealer.countryId.invalid");

                    dtoToSave.CountryId = dto.CountryId;
                }

            }
            if (!String.IsNullOrEmpty(dto.FirstName)) dtoToSave.FirstName = dto.FirstName;
            if (!String.IsNullOrEmpty(dto.FirstName)) dtoToSave.FirstName = dto.FirstName;

            dtoToSave.ChangedOn = DateTime.Now;
            dtoToSave.ChangedBy = dto.ChangedBy;
            dtoToSave = dealerDAC.Save(dtoToSave);
            return dtoToSave;
        }
    }
}
