using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCGA.Entities;

namespace MCGA.UI.Process
{
	public class TipoEspecialidadProcess : IDisposable
	{
		private Business.TipoEspecialidadComponent business = new Business.TipoEspecialidadComponent();

		public List<TipoEspecialidad> GetAll()
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

		public TipoEspecialidad GetById(int? id)
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

		public void Add(TipoEspecialidad tipoEspecialidad)
		{
			try
			{
				business.Add(tipoEspecialidad);
			}
			catch
			{
				throw;
			}
		}

		public void Edit(TipoEspecialidad tipoEspecialidad)
		{
			try
			{
				business.Edit(tipoEspecialidad);
			}
			catch
			{
				throw;
			}
		}

		public void Remove(TipoEspecialidad tipoEspecialidad)
		{
			try
			{
				business.Remove(tipoEspecialidad);
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