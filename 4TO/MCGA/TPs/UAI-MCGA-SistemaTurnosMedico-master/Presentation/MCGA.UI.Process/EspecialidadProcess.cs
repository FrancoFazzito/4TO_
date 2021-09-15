using MCGA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA.UI.Process
{
	public class EspecialidadProcess : IDisposable
	{
		private Business.EspecialidadComponent business = new Business.EspecialidadComponent();

		public List<Especialidad> GetAll()
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

		public Especialidad GetById(int? id)
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

		public void Add(Especialidad especialidad)
		{
			try
			{
				business.Add(especialidad);
			}
			catch
			{
				throw;
			}
		}

		public void Edit(Especialidad especialidad)
		{
			try
			{
				business.Edit(especialidad);
			}
			catch
			{
				throw;
			}
		}

		public void Remove(Especialidad especialidad)
		{
			try
			{
				business.Remove(especialidad);
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
