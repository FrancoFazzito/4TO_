using MCGA.Data;
using MCGA.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MCGA.Business
{
	public class AgendaCancelacionComponent : IDisposable
	{
		private MedicureContext db = new MedicureContext();

		public List<AgendaCancelacion> GetAll()
		{
			try
			{
				return db.AgendaCancelacion.Include(a => a.Agenda).ToList();
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
				return db.AgendaCancelacion.Find(id);
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
				using (TransactionScope scope = new TransactionScope())
				{
					db.AgendaCancelacion.Add(agendaCancelacion);
					db.SaveChanges();

					scope.Complete();
				}
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
				using (TransactionScope scope = new TransactionScope())
				{
					db.Entry(agendaCancelacion).State = EntityState.Modified;
					db.SaveChanges();

					scope.Complete();
				}
			}
			catch
			{
				throw;
			}
		}

		public void Dispose()
		{
			db.Dispose();
		}
	}
}
