using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCGA.Constants
{
    public static class TipoResevaControllerRoute
	{
        public const string GetIndex = ControllerName.TipoReseva + "GetIndex";
		public const string GetCreate = ControllerName.TipoReseva + "GetCreate";
		public const string GetEdit = ControllerName.TipoReseva + "GetEdit";
		public const string GetDelete = ControllerName.TipoReseva + "GetDelete";

		public const string PostCreate = ControllerName.TipoReseva + "PostCreate";
		public const string PostEdit = ControllerName.TipoReseva + "PostEdit";
		public const string PostDelete = ControllerName.TipoReseva + "PostDelete";
	}
}