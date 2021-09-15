using MCGA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA.UI.Process
{
	public class CancelacionProcess : IDisposable
	{

		private Business.CancelacionComponent business = new Business.CancelacionComponent();

		public List<Cancelacion> GetAll()
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

		public Cancelacion GetById(int? id)
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

		public void Add(Cancelacion cancelacion)
		{
			try
			{
				business.Add(cancelacion);
			}
			catch
			{
				throw;
			}
		}

		public void Edit(Cancelacion cancelacion)
		{
			try
			{
				business.Edit(cancelacion);
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
