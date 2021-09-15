using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCGA.Constants
{
    public static class TipoEspecialidadControllerRoute
	{
        public const string GetIndex = ControllerName.TipoEspecialidad + "GetIndex";
		public const string GetCreate = ControllerName.TipoEspecialidad + "GetCreate";
		public const string GetEdit = ControllerName.TipoEspecialidad + "GetEdit";
		public const string GetDelete = ControllerName.TipoEspecialidad + "GetDelete";

		public const string PostCreate = ControllerName.TipoEspecialidad + "PostCreate";
		public const string PostEdit = ControllerName.TipoEspecialidad + "PostEdit";
		public const string PostDelete = ControllerName.TipoEspecialidad + "PostDelete";
	}
}