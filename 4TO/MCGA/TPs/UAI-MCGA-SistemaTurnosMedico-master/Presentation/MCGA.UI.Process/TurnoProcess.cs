using MCGA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA.UI.Process
{
	public class TurnoProcess : IDisposable
	{
		private Business.TurnoComponent business = new Business.TurnoComponent();

		public List<Turno> GetAll()
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

		public Turno GetById(int? id)
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

		public void Add(Turno turno)
		{
			try
			{
				business.Add(turno);
			}
			catch
			{
				throw;
			}
		}

		public void Edit(Turno turno)
		{
			try
			{
				business.Edit(turno);
			}
			catch
			{
				throw;
			}
		}

		public void Remove(Turno turno)
		{
			try
			{
				business.Remove(turno);
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
