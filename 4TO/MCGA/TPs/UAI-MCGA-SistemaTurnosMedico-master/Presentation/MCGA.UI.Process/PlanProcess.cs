using MCGA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA.UI.Process
{
	public class PlanProcess : IDisposable
	{
		private Business.PlanComponent business = new Business.PlanComponent();

		public List<Plan> GetAll()
		{
			try
			{
				return business.GetAll();
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
				return business.GetById(id);
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
				business.Add(plan);
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
				business.Edit(plan);
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
				business.Remove(plan);
			}
			catch
			{
				throw;
			}
		}

		public void Dispose()
		{
			business.Dispose();
		}
	}
}
