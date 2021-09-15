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
	public class TipoCancelacionComponent : IDisposable
	{
		private MedicureContext db = new MedicureContext();

		public List<TipoCancelacion> GetAll()
		{
			try
			{
				return db.TipoCancelacion.ToList();
			}
			catch
			{
				throw;
			}
		}

		public TipoCancelacion GetById(int? id)
		{
			try
			{
				return db.TipoCancelacion.Find(id);
			}
			catch
			{
				throw;
			}
		}

		public void Add(TipoCancelacion tipoCancelacion)
		{
			try
			{
				using (TransactionScope scope = new TransactionScope())
				{
					db.TipoCancelacion.Add(tipoCancelacion);
					db.SaveChanges();

					scope.Complete();
				}
			}
			catch
			{
				throw;
			}
		}

		public void Edit(TipoCancelacion tipoCancelacion)
		{
			try
			{
				using (TransactionScope scope = new TransactionScope())
				{
					db.Entry(tipoCancelacion).State = EntityState.Modified;
					db.SaveChanges();

					scope.Complete();
				}
			}
			catch
			{
				throw;
			}
		}

		public void Remove(TipoCancelacion tipoCancelacion)
		{
			try
			{
				using (TransactionScope scope = new TransactionScope())
				{
					db.TipoCancelacion.Remove(tipoCancelacion);
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

