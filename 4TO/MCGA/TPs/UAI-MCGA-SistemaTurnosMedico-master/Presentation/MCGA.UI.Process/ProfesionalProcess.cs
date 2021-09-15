using MCGA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA.UI.Process
{
	public class ProfesionalProcess : IDisposable
	{
		private Business.ProfesionalComponent business = new Business.ProfesionalComponent();

		public List<Profesional> GetAll()
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

		public Profesional GetById(int? id)
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

		public void Add(Profesional profesional)
		{
			try
			{
				business.Add(profesional);
			}
			catch
			{
				throw;
			}
		}

		public void Edit(Profesional profesional)
		{
			try
			{
				business.Edit(profesional);
			}
			catch
			{
				throw;
			}
		}

		public void Remove(Profesional profesional)
		{
			try
			{
				business.Remove(profesional);
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
