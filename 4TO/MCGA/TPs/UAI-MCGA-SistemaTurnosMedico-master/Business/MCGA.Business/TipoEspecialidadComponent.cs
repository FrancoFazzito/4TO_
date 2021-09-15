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
	public class TipoEspecialidadComponent : IDisposable
	{
		private MedicureContext db = new MedicureContext();

		public List<TipoEspecialidad> GetAll()
		{
			try
			{
				return db.TipoEspecialidad.ToList();
			}
			catch
			{
				throw;
			}
		}

		public TipoEspecialidad GetById(int? id)
		{
			try
			{
				return db.TipoEspecialidad.Find(id);
			}
			catch
			{
				throw;
			}
		}

		public void Add(TipoEspecialidad tipoEspecialidad)
		{
			try
			{
				using (TransactionScope scope = new TransactionScope())
				{
					db.TipoEspecialidad.Add(tipoEspecialidad);
					db.SaveChanges();

					scope.Complete();
				}
			}
			catch
			{
				throw;
			}
		}

		public void Edit(TipoEspecialidad tipoEspecialidad)
		{
			try
			{
				using (TransactionScope scope = new TransactionScope())
				{
					db.Entry(tipoEspecialidad).State = EntityState.Modified;
					db.SaveChanges();

					scope.Complete();
				}
			}
			catch
			{
				throw;
			}
		}

		public void Remove(TipoEspecialidad tipoEspecialidad)
		{
			try
			{
				using (TransactionScope scope = new TransactionScope())
				{
					db.TipoEspecialidad.Remove(tipoEspecialidad);
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
