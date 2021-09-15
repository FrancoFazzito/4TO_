using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCGA.Constants
{
    public static class AgendaControllerRoute
	{
        public const string GetIndex = ControllerName.Agenda + "GetIndex";
		public const string GetCreate = ControllerName.Agenda + "GetCreate";
		public const string GetEdit = ControllerName.Agenda + "GetEdit";
		public const string GetDelete = ControllerName.Agenda + "GetDelete";
		public const string GetCancelar = ControllerName.Agenda + "GetCancelar";

		public const string PostCreate = ControllerName.Agenda + "PostCreate";
		public const string PostEdit = ControllerName.Agenda + "PostEdit";
		public const string PostDelete = ControllerName.Agenda + "PostDelete";
		public const string PostCancelar = ControllerName.Agenda + "PostCancelar";
	}
}