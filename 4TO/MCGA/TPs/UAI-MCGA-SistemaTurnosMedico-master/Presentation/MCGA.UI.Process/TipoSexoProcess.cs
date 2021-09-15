using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCGA.Entities;

namespace MCGA.UI.Process
{
	public class TipoSexoProcess : IDisposable
	{
		private Business.TipoSexoComponent business = new Business.TipoSexoComponent();

		public List<TipoSexo> GetAll()
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

		public TipoSexo GetById(int? id)
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

		public void Add(TipoSexo tipoSexo)
		{
			try
			{
				business.Add(tipoSexo);
			}
			catch
			{
				throw;
			}
		}

		public void Edit(TipoSexo tipoSexo)
		{
			try
			{
				business.Edit(tipoSexo);
			}
			catch
			{
				throw;
			}
		}

		public void Remove(TipoSexo tipoSexo)
		{
			try
			{
				business.Remove(tipoSexo);
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