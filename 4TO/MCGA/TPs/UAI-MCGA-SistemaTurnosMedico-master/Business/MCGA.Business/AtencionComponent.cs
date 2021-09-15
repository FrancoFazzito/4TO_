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
	public class AtencionComponent : IDisposable
	{
		private MedicureContext db = new MedicureContext();

		public List<Atencion> GetAll()
		{
			try
			{
				return db.Atencion.Include(t => t.Turno).ToList();
			}
			catch
			{
				throw;
			}
		}

		public Atencion GetById(int? id)
		{
			try
			{
				return db.Atencion.Find(id);
			}
			catch
			{
				throw;
			}
		}

		public void Add(Atencion atencion)
		{
			try
			{
				using (TransactionScope scope = new TransactionScope())
				{
					db.Atencion.Add(atencion);
					db.SaveChanges();

					scope.Complete();
				}
			}
			catch
			{
				throw;
			}
		}

		public void Edit(Atencion atencion)
		{
			try
			{
				using (TransactionScope scope = new TransactionScope())
				{
					db.Entry(atencion).State = EntityState.Modified;
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
