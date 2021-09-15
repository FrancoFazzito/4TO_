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
	public class TipoKeyComponent : IDisposable
	{
		private MedicureContext db = new MedicureContext();

	public List<TipoKey> GetAll()
	{
		try
		{
			return db.TipoKey.Include(e => e.DetalleTipoKey).ToList();
		}
		catch
		{
			throw;
		}
	}

	public TipoKey GetById(int? id)
	{
		try
		{
			return db.TipoKey.Find(id);
		}
		catch
		{
			throw;
		}
	}

	public void Add(TipoKey tipoKey)
	{
		try
		{
			using (TransactionScope scope = new TransactionScope())
			{
				db.TipoKey.Add(tipoKey);
				db.SaveChanges();

				scope.Complete();
			}
		}
		catch
		{
			throw;
		}
	}

	public void Edit(TipoKey tipoKey)
	{
		try
		{
			using (TransactionScope scope = new TransactionScope())
			{
				db.Entry(tipoKey).State = EntityState.Modified;
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
