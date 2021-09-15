using System;
using System.Configuration;
using System.Data;
using System.Text.RegularExpressions;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ArtMarket.Data
{
    public abstract class DataAccessComponent
    {
        protected const string ConnectionName = "DefaultConnection";

        static DataAccessComponent()
        {
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(), false);
        }

        protected int PageSize => Convert.ToInt32(ConfigurationManager.AppSettings["PageSize"]);

        protected static T GetDataValue<T>(IDataReader dr, string columnName)
        {
            int i = dr.GetOrdinal(columnName);
            if (!dr.IsDBNull(i))
                return (T)dr.GetValue(i);
            else
                return default(T);
        }

        protected string FormatFilterStatement(string filter)
        {
            return Regex.Replace(filter, "^(AND|OR)", string.Empty);
        }
    }
}
