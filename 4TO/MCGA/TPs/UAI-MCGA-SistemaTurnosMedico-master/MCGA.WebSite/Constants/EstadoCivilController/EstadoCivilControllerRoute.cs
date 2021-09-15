using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCGA.Constants
{
    public static class EstadoCivilControllerRoute
	{
        public const string GetIndex = ControllerName.EstadoCivil + "GetIndex";
		public const string GetCreate = ControllerName.EstadoCivil + "GetCreate";
		public const string GetEdit = ControllerName.EstadoCivil + "GetEdit";
		public const string GetDelete = ControllerName.EstadoCivil + "GetDelete";

		public const string PostCreate = ControllerName.EstadoCivil + "PostCreate";
		public const string PostEdit = ControllerName.EstadoCivil + "PostEdit";
		public const string PostDelete = ControllerName.EstadoCivil + "PostDelete";
	}
}