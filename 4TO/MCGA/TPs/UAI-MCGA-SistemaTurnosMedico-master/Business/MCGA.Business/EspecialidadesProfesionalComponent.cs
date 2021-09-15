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
	public class EspecialidadesProfesionalComponent : IDisposable
	{
		private MedicureContext db = new MedicureContext();

		public List<EspecialidadesProfesional> GetAll()
		{
			try
			{
				return db.EspecialidadesProfesional.Include(e => e.Especialidad).Include(e => e.Profesional).ToList();
			}
			catch
			{
				throw;
			}
		}

		public EspecialidadesProfesional GetById(int? id)
		{
			try
			{
				return db.EspecialidadesProfesional.Find(id);
			}
			catch
			{
				throw;
			}
		}

		public void Add(EspecialidadesProfesional especialidadesProfesional)
		{
			try
			{
				using (TransactionScope scope = new TransactionScope())
				{
					db.EspecialidadesProfesional.Add(especialidadesProfesional);
					db.SaveChanges();

					scope.Complete();
				}
			}
			catch
			{
				throw;
			}
		}

		public void Edit(EspecialidadesProfesional especialidadProfesional)
		{
			try
			{
				using (TransactionScope scope = new TransactionScope())
				{
					db.Entry(especialidadProfesional).State = EntityState.Modified;
					db.SaveChanges();

					scope.Complete();
				}
			}
			catch
			{
				throw;
			}
		}

		public void Remove(EspecialidadesProfesional especialidadProfesional)
		{
			try
			{
				using (TransactionScope scope = new TransactionScope())
				{
					db.EspecialidadesProfesional.Remove(especialidadProfesional);
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
