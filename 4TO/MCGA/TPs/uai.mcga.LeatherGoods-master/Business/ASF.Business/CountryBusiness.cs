using ASF.Data;
using ASF.Entities;
using System;
using System.Collections.Generic;


namespace ASF.Business
{
    public class CountryBusiness : AbstractBussiness
    {
        CountryDAC countryDAC = new CountryDAC();
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id)
        {
            countryDAC.DeleteById(id);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Country> All()
        {

            var result = countryDAC.SelectAll();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Country Find(int id)
        {
            return countryDAC.SelectById(id);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        public Country Save(Country dto)
        {
            Country update = null;

            if ( dto.Id > 0)
            {
                update = countryDAC.SelectById(dto.Id);
                update.CreatedOn = DateTime.Now;
            } else
            {
                update = new Country();
                update.CreatedOn = DateTime.Now;
            }

            if (string.IsNullOrEmpty(dto.Name) == false )
            {
                update.Name = dto.Name;

            } else
            {
                throw new BusinessException("Invalid Name");
            }

            update.ChangedOn = DateTime.Now;

            var saved = countryDAC.Save(update);

            return saved;
        }
    }
}

