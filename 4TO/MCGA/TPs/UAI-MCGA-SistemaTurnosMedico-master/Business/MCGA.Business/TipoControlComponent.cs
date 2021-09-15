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
	public class TipoControlComponent : IDisposable
	{
		private MedicureContext db = new MedicureContext();

		public List<TipoCampo> GetAll()
		{
			try
			{
				return db.TipoCampo.ToList();
			}
			catch
			{
				throw;
			}
		}

		public TipoCampo GetById(int? id)
		{
			try
			{
				return db.TipoCampo.Find(id);
			}
			catch
			{
				throw;
			}
		}

		public void Add(TipoCampo tipoCampo)
		{
			try
			{
				using (TransactionScope scope = new TransactionScope())
				{
					db.TipoCampo.Add(tipoCampo);
					db.SaveChanges();

					scope.Complete();
				}
			}
			catch
			{
				throw;
			}
		}

		public void Edit(TipoCampo tipoCampo)
		{
			try
			{
				using (TransactionScope scope = new TransactionScope())
				{
					db.Entry(tipoCampo).State = EntityState.Modified;
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
