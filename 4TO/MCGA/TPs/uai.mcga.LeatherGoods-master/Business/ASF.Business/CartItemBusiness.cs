using System;
using System.Collections.Generic;
using ASF.Data;
using ASF.Entities;

namespace ASF.Business
{
    public class CartItemBusiness : AbstractBussiness
    {
        CartItemDAC cartItemDAC = new CartItemDAC();
        ProductBusiness productBusiness = new ProductBusiness();
        
        CartBusiness cartBusiness = new CartBusiness();
        
        /// <summary>
        /// Add method. 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public CartItem Save(CartItem dto)
        {
            CartItem update = dto.Id > 0 ? cartItemDAC.FindById<CartItem>(dto.Id) : new CartItem {CreatedOn = DateTime.Now};

            if (dto.ProductId <= 0)
            {
                throw new BusinessException("b.validation.cartitem.productId.missing");
            }
            
        
            var product = productBusiness.Find(dto.ProductId);
            if (product == null)
            {
                throw new BusinessException("b.validation.cartitem.productId.invalid");
            }

            update.ProductId = dto.ProductId;
            
            if (dto.CartId <= 0) throw new BusinessException("b.validation.cartitem.cartId.invalid");
            if (cartBusiness.Find(dto.CartId) == null) throw new BusinessException("b.validation.cartitem.cartId.invalid");

            update.CartId = dto.CartId;


            update.Price = dto.Price <= 0
                ? throw new BusinessException("b.validation.cartitem.price.invalid")
                : dto.Price;

            update.Quantity = dto.Quantity <= 0
                ? throw new BusinessException("b.validation.cartitem.quantity.invalid")
                : dto.Quantity;
            
            
            update.ChangedOn = DateTime.Now;
            update.ChangedBy = dto.ChangedBy;
            
            var saved = cartItemDAC.Save(dto);
            return saved;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id)
        {
            cartItemDAC.DeleteById(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<CartItem> All()
        {

            var result = cartItemDAC.SelectAll();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CartItem Find(int id)
        {
            return cartItemDAC.SelectById(id);

        }

    }
}