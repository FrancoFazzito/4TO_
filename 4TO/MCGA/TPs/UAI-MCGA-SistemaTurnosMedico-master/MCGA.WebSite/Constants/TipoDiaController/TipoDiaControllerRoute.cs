using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCGA.Constants
{
    public static class TipoDiaControllerRoute
	{
        public const string GetIndex = ControllerName.TipoDia + "GetIndex";
		public const string GetCreate = ControllerName.TipoDia + "GetCreate";
		public const string GetEdit = ControllerName.TipoDia + "GetEdit";
		public const string GetDelete = ControllerName.TipoDia + "GetDelete";

		public const string PostCreate = ControllerName.TipoDia + "PostCreate";
		public const string PostEdit = ControllerName.TipoDia + "PostEdit";
		public const string PostDelete = ControllerName.TipoDia + "PostDelete";
	}
}