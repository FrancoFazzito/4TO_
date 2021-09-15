using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCGA.Constants
{
    public static class ProfesionalControllerRoute
	{
        public const string GetIndex = ControllerName.Profesional + "GetIndex";
		public const string GetCreate = ControllerName.Profesional + "GetCreate";
		public const string GetEdit = ControllerName.Profesional + "GetEdit";
		public const string GetDelete = ControllerName.Profesional + "GetDelete";

		public const string PostCreate = ControllerName.Profesional + "PostCreate";
		public const string PostEdit = ControllerName.Profesional + "PostEdit";
		public const string PostDelete = ControllerName.Profesional + "PostDelete";
	}
}