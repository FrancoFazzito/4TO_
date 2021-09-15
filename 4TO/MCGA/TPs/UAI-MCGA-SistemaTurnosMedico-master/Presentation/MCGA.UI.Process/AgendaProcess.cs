using MCGA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA.UI.Process
{
	public class AgendaProcess : IDisposable
	{
		private Business.AgendaComponent business = new Business.AgendaComponent();

		public List<Agenda> GetAll()
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

		public Agenda GetById(int? id)
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

		public void Add(Agenda agenda)
		{
			try
			{
				business.Add(agenda);
			}
			catch
			{
				throw;
			}
		}

		public void Edit(Agenda agenda)
		{
			try
			{
				business.Edit(agenda);
			}
			catch
			{
				throw;
			}
		}

		public void Remove(Agenda agenda)
		{
			try
			{
				business.Remove(agenda);
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
