using MCGA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA.UI.Process
{
	public class TipoKeyProcess : IDisposable
	{
		private Business.TipoKeyComponent business = new Business.TipoKeyComponent();

		public List<TipoKey> GetAll()
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

		public TipoKey GetById(int? id)
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

		public void Add(TipoKey tipoKey)
		{
			try
			{
				business.Add(tipoKey);
			}
			catch
			{
				throw;
			}
		}

		public void Edit(TipoKey tipoKey)
		{
			try
			{
				business.Edit(tipoKey);
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