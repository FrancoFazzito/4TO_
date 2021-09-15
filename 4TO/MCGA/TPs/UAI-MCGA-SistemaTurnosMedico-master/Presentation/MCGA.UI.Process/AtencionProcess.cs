using MCGA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA.UI.Process
{
	public class AtencionProcess : IDisposable
	{

		private Business.AtencionComponent business = new Business.AtencionComponent();

		public List<Atencion> GetAll()
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

		public Atencion GetById(int? id)
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

		public void Add(Atencion atencion)
		{
			try
			{
				business.Add(atencion);
			}
			catch
			{
				throw;
			}
		}

		public void Edit(Atencion atencion)
		{
			try
			{
				business.Edit(atencion);
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
