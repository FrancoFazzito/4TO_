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
	public class AgendaComponent : IDisposable
	{
		private MedicureContext db = new MedicureContext();

		public List<Agenda> GetAll()
		{
			try
			{
				return db.Agenda.Include(a => a.EspecialidadesProfesional).Include(a => a.TipoDia).Where(a=> a.isdeleted == false).ToList();
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
				return db.Agenda.Find(id);
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
				using (TransactionScope scope = new TransactionScope())
				{
					db.Agenda.Add(agenda);
					db.SaveChanges();

					scope.Complete();
				}
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
				using (TransactionScope scope = new TransactionScope())
				{
					db.Entry(agenda).State = EntityState.Modified;
					db.SaveChanges();

					scope.Complete();
				}
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
				using (TransactionScope scope = new TransactionScope())
				{
					agenda.isdeleted = true;
					agenda.deletedby = "1";
					agenda.deletedon = DateTime.Now;
					db.Entry(agenda).State = EntityState.Modified;
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
