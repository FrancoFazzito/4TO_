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
	public class DatoAdicionalAfiliadoComponent : IDisposable
	{
		private MedicureContext db = new MedicureContext();

		public List<DatoAdicionalAfiliado> GetAll()
		{
			try
			{
				return db.DatoAdicionalAfiliado.Include(a => a.Afiliado).Include(tk => tk.TipoKey).ToList();
			}
			catch
			{
				throw;
			}
		}

		public DatoAdicionalAfiliado GetById(int? id)
		{
			try
			{
				return db.DatoAdicionalAfiliado.Find(id);
			}
			catch
			{
				throw;
			}
		}

		public void Add(DatoAdicionalAfiliado datoAdicionalAfiliado)
		{
			try
			{
				using (TransactionScope scope = new TransactionScope())
				{
					db.DatoAdicionalAfiliado.Add(datoAdicionalAfiliado);
					db.SaveChanges();

					scope.Complete();
				}
			}
			catch
			{
				throw;
			}
		}

		public void Edit(DatoAdicionalAfiliado datoAdicionalAfiliado)
		{
			try
			{
				using (TransactionScope scope = new TransactionScope())
				{
					db.Entry(datoAdicionalAfiliado).State = EntityState.Modified;
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
