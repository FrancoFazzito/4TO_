using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCGA.Entities;

namespace MCGA.UI.Process
{
	public class EstadoCivilProcess : IDisposable
	{
		private Business.EstadoCivilComponent business = new Business.EstadoCivilComponent();

		public List<EstadoCivil> GetAll()
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

		public EstadoCivil GetById(int? id)
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

		public void Add(EstadoCivil estadoCivil)
		{
			try
			{
				business.Add(estadoCivil);
			}
			catch
			{
				throw;
			}
		}

		public void Edit(EstadoCivil estadoCivil)
		{
			try
			{
				business.Edit(estadoCivil);
			}
			catch
			{
				throw;
			}
		}

		public void Remove(EstadoCivil estadoCivil)
		{
			try
			{
				business.Remove(estadoCivil);
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
