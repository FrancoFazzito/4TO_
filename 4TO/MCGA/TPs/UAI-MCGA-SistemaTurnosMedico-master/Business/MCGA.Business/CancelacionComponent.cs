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
	public class CancelacionComponent : IDisposable
	{
		private MedicureContext db = new MedicureContext();

		public List<Cancelacion> GetAll()
		{
			try
			{
				return db.Cancelacion.Include(t => t.Turno).ToList();
			}
			catch
			{
				throw;
			}
		}

		public Cancelacion GetById(int? id)
		{
			try
			{
				return db.Cancelacion.Find(id);
			}
			catch
			{
				throw;
			}
		}

		public void Add(Cancelacion cancelacion)
		{
			try
			{
				using (TransactionScope scope = new TransactionScope())
				{
					db.Cancelacion.Add(cancelacion);
					db.SaveChanges();

					scope.Complete();
				}
			}
			catch
			{
				throw;
			}
		}

		public void Edit(Cancelacion cancelacion)
		{
			try
			{
				using (TransactionScope scope = new TransactionScope())
				{
					db.Entry(cancelacion).State = EntityState.Modified;
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
