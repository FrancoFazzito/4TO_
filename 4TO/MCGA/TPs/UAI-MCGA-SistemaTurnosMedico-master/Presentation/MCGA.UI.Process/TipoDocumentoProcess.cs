using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCGA.Entities;

namespace MCGA.UI.Process
{
	public class TipoDocumentoProcess : IDisposable
	{
		private Business.TipoDocumentoComponent business = new Business.TipoDocumentoComponent();

		public List<TipoDocumento> GetAll()
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

		public TipoDocumento GetById(int? id)
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

		public void Add(TipoDocumento tipoDocumento)
		{
			try
			{
				business.Add(tipoDocumento);
			}
			catch
			{
				throw;
			}
		}

		public void Edit(TipoDocumento tipoDocumento)
		{
			try
			{
				business.Edit(tipoDocumento);
			}
			catch
			{
				throw;
			}
		}

		public void Remove(TipoDocumento tipoDocumento)
		{
			try
			{
				business.Remove(tipoDocumento);
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
