using System.Web.Mvc;

namespace ArtMarket.UI.Web.Controllers
{
	public class BaseController : Controller
	{
		/*


		public IErrorManagement ErrorManagment { get; set; }

		public BaseController()
		{
			ErrorManagment = new ErrorMangement();
		}

		protected bool ModelIsValid(List<ValidationResult> listModel)
		{
			var message = string.Empty;
			var result = listModel != null && listModel.Count > 0;
			if (result)
			{
				foreach (var item in listModel)
					message += string.Format("{0}\r\n", item.ErrorMessage);
				ViewBag.MessageDanger = message;
			}

			return result;
		}

		protected void CheckAuditPattern(dynamic model, bool created = false)
		{
			string userId = TryGetUserId();
			if (created)
			{
				model.CreatedOn = DateTime.Now;
				model.CreatedBy = userId;
				model.ChangedOn = DateTime.Now;
			}
			model.ChangedOn = DateTime.Now;
			model.ChangedBy = userId;
		}

		protected virtual string TryGetUserId()
		{
			if (!User.Identity.IsAuthenticated)
				return null;

			string userId = null;
			try
			{
				userId = User.Identity.Name;
				if (userId != null)
					return userId;
			}
			catch { }

			return userId;
		}

		protected override void OnException(ExceptionContext filterContext)
		{
			Error error = new Error();
			CheckAuditPattern(error, true);
			error.ErrorDate = DateTime.Now;
			error.Exception = filterContext.Exception.GetType().ToString();
			error.Message = filterContext.Exception.Message.ToString();
			try
			{
				ErrorManagment.AddError(error);
				base.OnException(filterContext);
			}
			catch (Exception ex)
			{
				base.OnException(filterContext);
			}
		}


		 */
	}
}