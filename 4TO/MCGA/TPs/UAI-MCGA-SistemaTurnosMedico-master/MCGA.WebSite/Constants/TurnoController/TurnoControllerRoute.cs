using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCGA.Constants
{
    public static class TurnoControllerRoute
	{
        public const string GetIndex = ControllerName.Turno + "GetIndex";
		public const string GetCreate = ControllerName.Turno + "GetCreate";
		public const string GetEdit = ControllerName.Turno + "GetEdit";
		public const string GetDelete = ControllerName.Turno + "GetDelete";

		public const string PostCreate = ControllerName.Turno + "PostCreate";
		public const string PostEdit = ControllerName.Turno + "PostEdit";
		public const string PostDelete = ControllerName.Turno + "PostDelete";
	}
}