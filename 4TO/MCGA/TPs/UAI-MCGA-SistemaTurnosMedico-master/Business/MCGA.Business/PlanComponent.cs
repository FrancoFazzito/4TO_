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
	public class PlanComponent : IDisposable
	{
		private MedicureContext db = new MedicureContext();

		public List<Plan> GetAll()
		{
			try
			{
				return db.Plan.Where(p => p.isdeleted == false).ToList();
			}
			catch
			{
				throw;
			}
		}

		public Plan GetById(int? id)
		{
			try
			{
				return db.Plan.Find(id);
			}
			catch
			{
				throw;
			}
		}

		public void Add(Plan plan)
		{
			try
			{
				using (TransactionScope scope = new TransactionScope())
				{
					db.Plan.Add(plan);
					db.SaveChanges();

					scope.Complete();
				}
			}
			catch
			{
				throw;
			}
		}

		public void Edit(Plan plan)
		{
			try
			{
				using (TransactionScope scope = new TransactionScope())
				{
					db.Entry(plan).State = EntityState.Modified;
					db.SaveChanges();

					scope.Complete();
				}
			}
			catch
			{
				throw;
			}
		}

		public void Remove(Plan plan)
		{
			try
			{
				using (TransactionScope scope = new TransactionScope())
				{
					plan.isdeleted = true;
					plan.deletedby="1";
					plan.deletedon=DateTime.Now;
					db.Entry(plan).State = EntityState.Modified;
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
