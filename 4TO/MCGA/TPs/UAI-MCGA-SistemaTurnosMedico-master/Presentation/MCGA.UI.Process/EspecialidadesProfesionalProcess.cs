using MCGA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA.UI.Process
{
	public class EspecialidadesProfesionalProcess : IDisposable
	{
		private Business.EspecialidadesProfesionalComponent business = new Business.EspecialidadesProfesionalComponent();

		public List<EspecialidadesProfesional> GetAll()
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

		public EspecialidadesProfesional GetById(int? id)
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

		public void Add(EspecialidadesProfesional especialidadesProfesional)
		{
			try
			{
				business.Add(especialidadesProfesional);
			}
			catch
			{
				throw;
			}
		}

		public void Edit(EspecialidadesProfesional especialidadesProfesional)
		{
			try
			{
				business.Edit(especialidadesProfesional);
			}
			catch
			{
				throw;
			}
		}

		public void Remove(EspecialidadesProfesional especialidadesProfesional)
		{
			try
			{
				business.Remove(especialidadesProfesional);
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
