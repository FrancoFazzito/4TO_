using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCGA.Entities;

namespace MCGA.UI.Process
{
	public class TipoResevaProcess : IDisposable
	{
		private Business.TipoResevaComponent business = new Business.TipoResevaComponent();

		public List<TipoReseva> GetAll()
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

		public TipoReseva GetById(int? id)
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

		public void Add(TipoReseva tipoReseva)
		{
			try
			{
				business.Add(tipoReseva);
			}
			catch
			{
				throw;
			}
		}

		public void Edit(TipoReseva tipoReseva)
		{
			try
			{
				business.Edit(tipoReseva);
			}
			catch
			{
				throw;
			}
		}

		public void Remove(TipoReseva tipoReseva)
		{
			try
			{
				business.Remove(tipoReseva);
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