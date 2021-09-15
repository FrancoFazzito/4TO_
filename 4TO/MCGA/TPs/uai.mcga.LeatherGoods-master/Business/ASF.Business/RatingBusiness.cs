using System;
using System.Collections.Generic;
using ASF.Data;
using ASF.Entities;

namespace ASF.Business
{
    public class RatingBusiness : AbstractBussiness
    {
        RatingDAC ratingDAC = new RatingDAC();
    
        ClientBusiness clientBusiness = new ClientBusiness();
        ProductBusiness productBusiness = new ProductBusiness();
        /// <summary>
        /// Add method. 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public Rating Save(Rating dto)
        {
            Rating update = dto.Id > 0
                ? ratingDAC.FindById<Rating>(dto.Id)
                : new Rating {CreatedOn = DateTime.Now, CreatedBy = dto.CreatedBy};


            if (dto.ClientId <= 0)
            {
                throw new BusinessException("b.validation.rating.clientId.invalid");
            }
            if (clientBusiness.Find(dto.ClientId) == null)
            {
                throw new BusinessException("b.validation.rating.clientId.missing");                
            }

            update.ClientId = dto.ClientId;
            
            
            if (dto.ProductId <= 0)
            {
                throw new BusinessException("b.validation.rating.productId.invalid");
            }
            if (productBusiness.Find(dto.ProductId) == null)
            {
                throw new BusinessException("b.validation.rating.productId.missing");                
            }

            update.Stars = dto.Stars < 0 ? throw new BusinessException("b.validation.rating.productId.missing") : dto.Stars;
            
            update.ChangedOn = DateTime.Now;
            update.ChangedBy = dto.ChangedBy;
            var saved = ratingDAC.Save(dto);
            return saved;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id)
        {
            ratingDAC.DeleteById(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Rating> All()
        {

            var result = ratingDAC.SelectAll();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Rating Find(int id)
        {
            return ratingDAC.SelectById(id);

        }

        
    }
}