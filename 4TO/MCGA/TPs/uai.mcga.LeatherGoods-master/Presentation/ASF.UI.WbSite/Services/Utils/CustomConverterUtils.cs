using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace ASF.UI.WbSite.Services.Utils
{
    public class CustomConverterUtils
    {
        public static T MapFormCollection<T>(FormCollection form)
        {
            T obj = Activator.CreateInstance<T>();

            foreach (var propertyKey in form.Keys)
            {
                var bindingProperty = obj.GetType().GetProperty(propertyKey.ToString());
                bindingProperty.SetValue(obj, form[propertyKey.ToString()]);
            }
            

            return obj;
        }

    }
}