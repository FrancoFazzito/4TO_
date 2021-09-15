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
	public class TurnoComponent : IDisposable
	{
		private MedicureContext db = new MedicureContext();

		public List<Turno> GetAll()
		{
			try
			{
				return db.Turno.Include(t => t.Afiliado).Include(t => t.EspecialidadesProfesional).Where(t => t.isdeleted == false).ToList();
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
				return db.Turno.Find(id);
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
				using (TransactionScope scope = new TransactionScope())
				{
					db.Turno.Add(turno);
					db.SaveChanges();

					scope.Complete();
				}
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
				using (TransactionScope scope = new TransactionScope())
				{
					db.Entry(turno).State = EntityState.Modified;
					db.SaveChanges();

					scope.Complete();
				}
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
				using (TransactionScope scope = new TransactionScope())
				{
					turno.isdeleted = true;
					turno.deletedby = "1";
					turno.deletedon = DateTime.Now;
					db.Entry(turno).State = EntityState.Modified;
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
