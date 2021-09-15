using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCGA.Constants
{
    public static class PlanControllerRoute
	{
        public const string GetIndex = ControllerName.Plan + "GetIndex";
		public const string GetCreate = ControllerName.Plan + "GetCreate";
		public const string GetEdit = ControllerName.Plan + "GetEdit";
		public const string GetDelete = ControllerName.Plan + "GetDelete";

		public const string PostCreate = ControllerName.Plan + "PostCreate";
		public const string PostEdit = ControllerName.Plan + "PostEdit";
		public const string PostDelete = ControllerName.Plan + "PostDelete";
	}
}