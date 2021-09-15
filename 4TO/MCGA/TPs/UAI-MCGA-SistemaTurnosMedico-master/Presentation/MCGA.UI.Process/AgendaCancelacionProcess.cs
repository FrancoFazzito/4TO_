using MCGA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA.UI.Process
{
	public class AgendaCancelacionProcess : IDisposable
	{

		private Business.AgendaCancelacionComponent business = new Business.AgendaCancelacionComponent();

		public List<AgendaCancelacion> GetAll()
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

		public AgendaCancelacion GetById(int? id)
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

		public void Add(AgendaCancelacion agendaCancelacion)
		{
			try
			{
				business.Add(agendaCancelacion);
			}
			catch
			{
				throw;
			}
		}

		public void Edit(AgendaCancelacion agendaCancelacion)
		{
			try
			{
				business.Edit(agendaCancelacion);
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
