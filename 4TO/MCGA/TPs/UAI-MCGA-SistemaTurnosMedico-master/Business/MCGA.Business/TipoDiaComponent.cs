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
	public class TipoDiaComponent : IDisposable
	{
		private MedicureContext db = new MedicureContext();

		public List<TipoDia> GetAll()
		{
			try
			{
				return db.TipoDia.ToList();
			}
			catch
			{
				throw;
			}
		}

		public TipoDia GetById(int? id)
		{
			try
			{
				return db.TipoDia.Find(id);
			}
			catch
			{
				throw;
			}
		}

		public void Add(TipoDia tipoDia)
		{
			try
			{
				using (TransactionScope scope = new TransactionScope())
				{ 
					db.TipoDia.Add(tipoDia);
					db.SaveChanges();

					scope.Complete();
				}
			}
			catch
			{
				throw;
			}
		}

		public void Edit(TipoDia tipoDia)
		{
			try
			{
				using (TransactionScope scope = new TransactionScope())
				{
					db.Entry(tipoDia).State = EntityState.Modified;
					db.SaveChanges();

					scope.Complete();
				}
			}
			catch
			{
				throw;
			}
		}

		public void Remove(TipoDia tipoDia)
		{
			try
			{
				using (TransactionScope scope = new TransactionScope())
				{
					db.TipoDia.Remove(tipoDia);
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
