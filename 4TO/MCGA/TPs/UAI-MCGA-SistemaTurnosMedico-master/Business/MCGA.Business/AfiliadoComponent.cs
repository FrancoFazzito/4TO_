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
	public class AfiliadoComponent : IDisposable
	{
		private MedicureContext db = new MedicureContext();

		public List<Afiliado> GetAll()
		{
			try
			{
				return db.Afiliado.Include(a => a.EstadoCivil).Include(a => a.Plan).Include(a => a.TipoDocumento).Include(a => a.TipoSexo).Where(a => a.isdeleted == false).ToList();
			}
			catch
			{
				throw;
			}
		}

		public Afiliado GetById(int? id)
		{
			try
			{
				return db.Afiliado.Find(id);
			}
			catch
			{
				throw;
			}
		}

		public void Add(Afiliado afiliado)
		{
			try
			{
				using (TransactionScope scope = new TransactionScope())
				{
					db.Afiliado.Add(afiliado);
					db.SaveChanges();

					scope.Complete();
				}
			}
			catch
			{
				throw;
			}
		}

		public void Edit(Afiliado afiliado)
		{
			try
			{
				using (TransactionScope scope = new TransactionScope())
				{
					db.Entry(afiliado).State = EntityState.Modified;
					db.SaveChanges();

					scope.Complete();
				}
			}
			catch
			{
				throw;
			}
		}

		public void Remove(Afiliado afiliado)
		{
			try
			{
				using (TransactionScope scope = new TransactionScope())
				{
					afiliado.isdeleted = true;
					afiliado.deletedby = "1";
					afiliado.deletedon = DateTime.Now;
					db.Entry(afiliado).State = EntityState.Modified;
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
