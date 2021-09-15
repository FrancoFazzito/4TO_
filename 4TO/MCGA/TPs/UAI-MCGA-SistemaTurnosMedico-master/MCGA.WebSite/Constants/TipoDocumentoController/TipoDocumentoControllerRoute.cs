using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCGA.Constants
{
    public static class TipoDocumentoControllerRoute
	{
        public const string GetIndex = ControllerName.TipoDocumento + "GetIndex";
		public const string GetCreate = ControllerName.TipoDocumento + "GetCreate";
		public const string GetEdit = ControllerName.TipoDocumento + "GetEdit";
		public const string GetDelete = ControllerName.TipoDocumento + "GetDelete";

		public const string PostCreate = ControllerName.TipoDocumento + "PostCreate";
		public const string PostEdit = ControllerName.TipoDocumento + "PostEdit";
		public const string PostDelete = ControllerName.TipoDocumento + "PostDelete";
	}
}