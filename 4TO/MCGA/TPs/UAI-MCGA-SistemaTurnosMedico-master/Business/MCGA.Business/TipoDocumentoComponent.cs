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
	public class TipoDocumentoComponent : IDisposable
	{
		private MedicureContext db = new MedicureContext();

		public List<TipoDocumento> GetAll()
		{
			try
			{
				return db.TipoDocumento.ToList();
			}
			catch
			{
				throw;
			}
		}

		public TipoDocumento GetById(int? id)
		{
			try
			{
				return db.TipoDocumento.Find(id);
			}
			catch
			{
				throw;
			}
		}

		public void Add(TipoDocumento tipoDocumento)
		{
			try
			{
				using (TransactionScope scope = new TransactionScope())
				{
					db.TipoDocumento.Add(tipoDocumento);
					db.SaveChanges();

					scope.Complete();
				}
			}
			catch
			{
				throw;
			}
		}

		public void Edit(TipoDocumento tipoDocumento)
		{
			try
			{
				using (TransactionScope scope = new TransactionScope())
				{
					db.Entry(tipoDocumento).State = EntityState.Modified;
					db.SaveChanges();

					scope.Complete();
				}
			}
			catch
			{
				throw;
			}
		}

		public void Remove(TipoDocumento tipoDocumento)
		{
			try
			{
				using (TransactionScope scope = new TransactionScope())
				{
					db.TipoDocumento.Remove(tipoDocumento);
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
