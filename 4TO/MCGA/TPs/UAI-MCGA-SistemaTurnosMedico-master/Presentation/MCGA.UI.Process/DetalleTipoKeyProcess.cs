using MCGA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA.UI.Process
{
	public class DetalleTipoKeyProcess : IDisposable
	{
		private Business.DetalleTipoKeyComponent business = new Business.DetalleTipoKeyComponent();

		public List<DetalleTipoKey> GetAll()
		{
			try
			{
				return business.GetAll();
			}
			catch
			{
				throw;
			}
		}

		public DetalleTipoKey GetById(int? id)
		{
			try
			{
				return business.GetById(id);
			}
			catch
			{
				throw;
			}
		}

		public void Add(DetalleTipoKey detalleTipoKey)
		{
			try
			{
				business.Add(detalleTipoKey);
			}
			catch
			{
				throw;
			}
		}

		public void Edit(DetalleTipoKey detalleTipoKey)
		{
			try
			{
				business.Edit(detalleTipoKey);
			}
			catch
			{
				throw;
			}
		}

		public void Dispose()
		{
			business.Dispose();
		}
	}
}
