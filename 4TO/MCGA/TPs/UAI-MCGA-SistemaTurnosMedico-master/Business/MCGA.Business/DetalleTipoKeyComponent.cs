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
	public class DetalleTipoKeyComponent : IDisposable
	{
		private MedicureContext db = new MedicureContext();

		public List<DetalleTipoKey> GetAll()
		{
			try
			{
				return db.DetalleTipoKey.Include(tk => tk.TipoKey).Include(tc => tc.TipoCampo).ToList();
			}
			catch
			{
				throw;
			}
		}

		public DetalleTipoKey GetById(int? id)
		{
			try
			{
				return db.DetalleTipoKey.Find(id);
			}
			catch
			{
				throw;
			}
		}

		public void Add(DetalleTipoKey detalleTipoKey)
		{
			try
			{
				using (TransactionScope scope = new TransactionScope())
				{
					db.DetalleTipoKey.Add(detalleTipoKey);
					db.SaveChanges();

					scope.Complete();
				}
			}
			catch
			{
				throw;
			}
		}

		public void Edit(DetalleTipoKey detalleTipoKey)
		{
			try
			{
				using (TransactionScope scope = new TransactionScope())
				{
					db.Entry(detalleTipoKey).State = EntityState.Modified;
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
