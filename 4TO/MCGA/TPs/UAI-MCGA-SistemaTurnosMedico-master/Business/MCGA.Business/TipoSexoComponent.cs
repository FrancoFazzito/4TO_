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
	public class TipoSexoComponent : IDisposable
	{
		private MedicureContext db = new MedicureContext();

		public List<TipoSexo> GetAll()
		{
			try
			{
				return db.TipoSexo.ToList();
			}
			catch
			{
				throw;
			}
		}

		public TipoSexo GetById(int? id)
		{
			try
			{
				return db.TipoSexo.Find(id);
			}
			catch
			{
				throw;
			}
		}

		public void Add(TipoSexo tipoSexo)
		{
			try
			{
				using (TransactionScope scope = new TransactionScope())
				{
					db.TipoSexo.Add(tipoSexo);
					db.SaveChanges();

					scope.Complete();
				}
			}
			catch
			{
				throw;
			}
		}

		public void Edit(TipoSexo tipoSexo)
		{
			try
			{
				using (TransactionScope scope = new TransactionScope())
				{
					db.Entry(tipoSexo).State = EntityState.Modified;
					db.SaveChanges();

					scope.Complete();
				}
			}
			catch
			{
				throw;
			}
		}

		public void Remove(TipoSexo tipoSexo)
		{
			try
			{
				using (TransactionScope scope = new TransactionScope())
				{
					db.TipoSexo.Remove(tipoSexo);
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
