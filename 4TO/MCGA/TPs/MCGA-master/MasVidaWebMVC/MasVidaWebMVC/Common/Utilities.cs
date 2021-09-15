using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasVidaWebMVC.Common
{


    public class AppConstants
    {
        public enum UserType { ADMIN = 1, APPADMIN, CLIENT }

        public enum TransactionType { LIQUIDACION = 1, RECIBO, MOVCUENTA }

        public enum Months { ENERO = 1, FEBRERO, MARZO, ABRIL, MAYO, JUNIO, JULIO, AGOSTO, SEPTIEMBRE, OCTUBRE, NOVIEMBRE, DICIEMBRE }

    }

    public class Utilities
    {
        public static string GetMonth(int monthNbr)
        {
            switch (monthNbr)
            {
                case 1:
                    return AppConstants.Months.ENERO.ToString();
                case 2:
                    return AppConstants.Months.FEBRERO.ToString();
                case 3:
                    return AppConstants.Months.MARZO.ToString();
                case 4:
                    return AppConstants.Months.ABRIL.ToString();
                case 5:
                    return AppConstants.Months.MAYO.ToString();
                case 6:
                    return AppConstants.Months.JUNIO.ToString();
                case 7:
                    return AppConstants.Months.JULIO.ToString();
                case 8:
                    return AppConstants.Months.AGOSTO.ToString();
                case 9:
                    return AppConstants.Months.SEPTIEMBRE.ToString();
                case 10:
                    return AppConstants.Months.OCTUBRE.ToString();
                case 11:
                    return AppConstants.Months.NOVIEMBRE.ToString();
                case 12:
                    return AppConstants.Months.DICIEMBRE.ToString();
                default:
                    return "";
                    
            }
        }

    }

}