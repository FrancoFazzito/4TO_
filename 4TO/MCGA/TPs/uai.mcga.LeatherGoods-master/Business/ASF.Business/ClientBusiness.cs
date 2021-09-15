using System;
using System.Collections.Generic;
using ASF.Data;
using ASF.Entities;

namespace ASF.Business
{
    public class ClientBusiness : AbstractBussiness
    {
        private ClientDAC clientDAC = new ClientDAC();

        private CountryBusiness countryBusiness = new CountryBusiness();
        
        /// <summary>
        /// Add method. 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public Client Save(Client dto)
        {
            Client update;
            if (dto.Id > 0)
            {
                update = clientDAC.FindById<Client>(dto.Id);
            }
            else
            {
                update = new Client {CreatedOn = DateTime.Now};
            }

            if (string.IsNullOrEmpty(dto.FirstName))
            {
                throw new BusinessException("b.validation.client.firstname.invalid");
            }
            else
            {
                update.FirstName = dto.FirstName;
            }

            update.LastName = string.IsNullOrEmpty(dto.LastName)
                ? throw new BusinessException("b.validation.client.lastname.invalid")
                : dto.LastName;

            update.City = string.IsNullOrEmpty(dto.City)
                ? throw new BusinessException("b.validation.client.city.invalid")
                : dto.City;

            if (dto.CountryId > 0)
            {
                var country = countryBusiness.Find(dto.Id);

                if (country != null)
                {
                    update.CountryId = dto.CountryId;
                }
                else
                {
                    throw new BusinessException("b.validation.client.country.invalid");
                }
            }
            else
            {
                throw new BusinessException("b.validation.client.country.invalid");
            }


            if (update.Rowid == Guid.Empty)
            {
                update.Rowid = Guid.NewGuid();
            }
            
            update.ChangedOn = DateTime.Now;
            var saved = clientDAC.Save(dto);
            return saved;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id)
        {
            clientDAC.DeleteById(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Client> All()
        {

            var result = clientDAC.SelectAll();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Client Find(int id)
        {
            return clientDAC.SelectById(id);

        }

  
    }
}