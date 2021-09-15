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
	public class EspecialidadComponent : IDisposable
	{
		private MedicureContext db = new MedicureContext();

		public List<Especialidad> GetAll()
		{
			try
			{
				return db.Especialidad.Include(e => e.TipoEspecialidad).ToList();
			}
			catch
			{
				throw;
			}
		}

		public Especialidad GetById(int? id)
		{
			try
			{
				return db.Especialidad.Find(id);
			}
			catch
			{
				throw;
			}
		}

		public void Add(Especialidad especialidad)
		{
			try
			{
				using (TransactionScope scope = new TransactionScope())
				{
					db.Especialidad.Add(especialidad);
					db.SaveChanges();

					scope.Complete();
				}
			}
			catch
			{
				throw;
			}
		}

		public void Edit(Especialidad especialidad)
		{
			try
			{
				using (TransactionScope scope = new TransactionScope())
				{
					db.Entry(especialidad).State = EntityState.Modified;
					db.SaveChanges();

					scope.Complete();
				}
			}
			catch
			{
				throw;
			}
		}

		public void Remove(Especialidad especialidad)
		{
			try
			{
				using (TransactionScope scope = new TransactionScope())
				{
					db.Especialidad.Remove(especialidad);
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
