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
	public class ProfesionalComponent : IDisposable
	{
		private MedicureContext db = new MedicureContext();

		public List<Profesional> GetAll()
		{
			try
			{
				return db.Profesional.Include(p => p.TipoDocumento).Where(p=> p.isdeleted == false).ToList();
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
				return db.Profesional.Find(id);
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
				using (TransactionScope scope = new TransactionScope())
				{
					db.Profesional.Add(profesional);
					db.SaveChanges();

					scope.Complete();
				}
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
				using (TransactionScope scope = new TransactionScope())
				{
					db.Entry(profesional).State = EntityState.Modified;
					db.SaveChanges();

					scope.Complete();
				}
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
				using (TransactionScope scope = new TransactionScope())
				{
					profesional.isdeleted = true;
					profesional.deletedby = "1";
					profesional.deletedon = DateTime.Now;
					db.Entry(profesional).State = EntityState.Modified;
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
