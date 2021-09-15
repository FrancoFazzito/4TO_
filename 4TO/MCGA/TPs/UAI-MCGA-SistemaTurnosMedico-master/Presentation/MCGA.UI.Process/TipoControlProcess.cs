using MCGA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA.UI.Process
{
	public class TipoControlProcess : IDisposable
	{
		private Business.TipoControlComponent business = new Business.TipoControlComponent();

		public List<TipoCampo> GetAll()
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

		public TipoCampo GetById(int? id)
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

		public void Add(TipoCampo tipoCampo)
		{
			try
			{
				business.Add(tipoCampo);
			}
			catch
			{
				throw;
			}
		}

		public void Edit(TipoCampo tipoCampo)
		{
			try
			{
				business.Edit(tipoCampo);
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