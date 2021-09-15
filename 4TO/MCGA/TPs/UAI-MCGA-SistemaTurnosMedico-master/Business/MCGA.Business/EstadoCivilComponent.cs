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
	public class EstadoCivilComponent : IDisposable
	{
		private MedicureContext db = new MedicureContext();

		public List<EstadoCivil> GetAll()
		{
			try
			{
				return db.EstadoCivil.ToList();
			}
			catch
			{
				throw;
			}
		}

		public EstadoCivil GetById(int? id)
		{
			try
			{
				return db.EstadoCivil.Find(id);
			}
			catch
			{
				throw;
			}
		}

		public void Add(EstadoCivil estadoCivil)
		{
			try
			{
				using (TransactionScope scope = new TransactionScope())
				{
					db.EstadoCivil.Add(estadoCivil);
					db.SaveChanges();

					scope.Complete();
				}
			}
			catch
			{
				throw;
			}
		}

		public void Edit(EstadoCivil estadoCivil)
		{
			try
			{
				using (TransactionScope scope = new TransactionScope())
				{
					db.Entry(estadoCivil).State = EntityState.Modified;
					db.SaveChanges();

					scope.Complete();
				}
			}
			catch
			{
				throw;
			}
		}

		public void Remove(EstadoCivil estadoCivil)
		{
			try
			{
				using (TransactionScope scope = new TransactionScope())
				{
					db.EstadoCivil.Remove(estadoCivil);
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
