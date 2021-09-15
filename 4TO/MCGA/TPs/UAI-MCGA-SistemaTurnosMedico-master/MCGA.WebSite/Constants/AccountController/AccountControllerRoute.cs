using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCGA.Constants
{
    public static class AccountControllerRoute
	{
        public const string GetRegister = ControllerName.Account + "GetRegister";
        public const string GetLogin = ControllerName.Account + "GetLogin";
		public const string PostRegister = ControllerName.Account + "PostRegister";
		public const string PostLogin = ControllerName.Account + "PostLogin";
		
	}
}