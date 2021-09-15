using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCGA.Constants
{
    public static class AfiliadoControllerRoute
	{
        public const string GetIndex = ControllerName.Afiliado + "GetIndex";
		public const string GetCreate = ControllerName.Afiliado + "GetCreate";
		public const string GetEdit = ControllerName.Afiliado + "GetEdit";
		public const string GetDelete = ControllerName.Afiliado + "GetDelete";

		public const string PostCreate = ControllerName.Afiliado + "PostCreate";
		public const string PostEdit = ControllerName.Afiliado + "PostEdit";
		public const string PostDelete = ControllerName.Afiliado + "PostDelete";
	}
}