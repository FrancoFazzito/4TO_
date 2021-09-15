using System;
using System.Collections.Generic;
using ASF.Data;
using ASF.Entities;

namespace ASF.Business
{
    public class CartBusiness : AbstractBussiness
    {
        CartDAC cartDAC = new CartDAC();
        
         /// <summary>
        /// Add method. 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public Cart Save(Cart dto)
        {
            Cart update = dto.Id > 0 ? cartDAC.FindById<Cart>(dto.Id) : new Cart {CreatedOn = DateTime.Now};

            update.CartDate = dto.CartDate == null
                ? throw new BusinessException("b.validation.cart.cartdate.invalid")
                : dto.CartDate;

            update.Cookie = string.IsNullOrEmpty(dto.Cookie)
                ? throw new BusinessException("b.validation.cart.cookie.invalid")
                : dto.Cookie;

            update.Rowid = dto.Rowid == Guid.Empty ? Guid.NewGuid() : dto.Rowid;
            
            update.ChangedOn = DateTime.Now;
            update.ChangedBy = dto.ChangedBy;
            var saved = cartDAC.Save(dto);
            return saved;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id)
        {
            cartDAC.DeleteById(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Cart> All()
        {

            var result = cartDAC.SelectAll();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Cart Find(int id)
        {
            return cartDAC.SelectById(id);

        }

        
    }
}