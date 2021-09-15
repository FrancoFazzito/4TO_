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
	public class TipoResevaComponent : IDisposable
	{
		private MedicureContext db = new MedicureContext();

		public List<TipoReseva> GetAll()
		{
			try
			{
				return db.TipoReseva.ToList();
			}
			catch
			{
				throw;
			}
		}

		public TipoReseva GetById(int? id)
		{
			try
			{
				return db.TipoReseva.Find(id);
			}
			catch
			{
				throw;
			}
		}

		public void Add(TipoReseva tipoReseva)
		{
			try
			{
				using (TransactionScope scope = new TransactionScope())
				{ 
					db.TipoReseva.Add(tipoReseva);
					db.SaveChanges();

					scope.Complete();
				}
			}
			catch
			{
				throw;
			}
		}

		public void Edit(TipoReseva tipoReseva)
		{
			try
			{
				using (TransactionScope scope = new TransactionScope())
				{
					db.Entry(tipoReseva).State = EntityState.Modified;
					db.SaveChanges();

					scope.Complete();
				}
			}
			catch
			{
				throw;
			}
		}

		public void Remove(TipoReseva tipoReseva)
		{
			try
			{
				using (TransactionScope scope = new TransactionScope())
				{
					db.TipoReseva.Remove(tipoReseva);
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
