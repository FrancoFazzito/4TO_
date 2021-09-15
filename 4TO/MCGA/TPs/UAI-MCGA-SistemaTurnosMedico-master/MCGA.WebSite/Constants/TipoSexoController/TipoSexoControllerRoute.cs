using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCGA.Constants
{
    public static class TipoSexoControllerRoute
	{
        public const string GetIndex = ControllerName.TipoSexo + "GetIndex";
		public const string GetCreate = ControllerName.TipoSexo + "GetCreate";
		public const string GetEdit = ControllerName.TipoSexo + "GetEdit";
		public const string GetDelete = ControllerName.TipoSexo + "GetDelete";

		public const string PostCreate = ControllerName.TipoSexo + "PostCreate";
		public const string PostEdit = ControllerName.TipoSexo + "PostEdit";
		public const string PostDelete = ControllerName.TipoSexo + "PostDelete";
	}
}