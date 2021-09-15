using System;
using System.Collections.Generic;
using ASF.Data;
using ASF.Entities;

namespace ASF.Business
{
    public class ProductBusiness
    {
        ProductDAC productDAC = new ProductDAC();
        DealerBusiness dealerBusiness = new DealerBusiness();
        
        /// <summary>
        /// Add method. 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public Product Save(Product dto)
        {
            Product update = dto.Id > 0 ? productDAC.FindById<Product>(dto.Id) : new Product {CreatedOn = DateTime.Now};

            update.Description = string.IsNullOrEmpty(dto.Description)
                ? throw new BusinessException("b.validation.product.description.invalid")
                : dto.Description;

            update.Image = string.IsNullOrEmpty(dto.Image) 
                ? throw new BusinessException("b.validation.product.image.invalid")
                : dto.Image; 
            
            update.Price = dto.Price < 0 
                ? throw new BusinessException("b.validation.product.price.invalid")
                : dto.Price; 
            
            update.Title = string.IsNullOrEmpty(dto.Title) 
                ? throw new BusinessException("b.validation.product.title.invalid")
                : dto.Title;
            
            update.Rowid = dto.Rowid == null || dto.Rowid == Guid.Empty 
                ? Guid.NewGuid()
                : dto.Rowid;

            if (dto.DealerId <= 0 || dealerBusiness.Find(dto.DealerId) == null)
            {
                throw new BusinessException("b.validation.product.dealer.invalid");
            }
            else
            {
                update.DealerId = dto.DealerId;
            }
            
            
            update.ChangedOn = DateTime.Now;
            var saved = productDAC.Save(update);
            return saved;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id)
        {
            productDAC.DeleteById(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Product> All()
        {

            var result = productDAC.SelectAll();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product Find(int id)
        {
            return productDAC.SelectById(id);

        }

        
        
    }
}