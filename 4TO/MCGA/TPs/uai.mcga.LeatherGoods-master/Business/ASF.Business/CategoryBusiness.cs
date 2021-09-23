//====================================================================================================
// Base code generated with LeatherGoods - ASF.Business
// Architecture Solutions Foundation
//
// Generated by academic at LeatherGoods V 1.0 
//====================================================================================================

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ASF.Entities;
using ASF.Data;
using System.Diagnostics;

namespace ASF.Business
{
    /// <summary>
    /// CategoryBusiness business component.
    /// </summary>
    public class CategoryBusiness : AbstractBussiness
    {
        CategoryDAC categoryDAC = new CategoryDAC();
        /// <summary>
        /// Add method. 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public Category Add(Category category)
        {
            
            category.CreatedOn = DateTime.Now;
            category.ChangedOn = category.CreatedOn;
            var saved = categoryDAC.Save(category);
            return saved;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id)
        {
            categoryDAC.DeleteById(id);
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Category> All()
        {

            var result = categoryDAC.Select();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Category Find(int id)
        {
            return categoryDAC.SelectById(id);
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        public void Edit(Category category)
        {


            var cat = categoryDAC.SelectById(category.Id);

            cat.Name = category.Name;
            cat.ChangedOn = DateTime.Now;
            categoryDAC.Save(cat);
        }
    }
}