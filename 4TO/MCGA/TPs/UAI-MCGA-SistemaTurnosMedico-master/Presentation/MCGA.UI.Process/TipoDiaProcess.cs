using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCGA.Entities;

namespace MCGA.UI.Process
{
	public class TipoDiaProcess : IDisposable
	{
		private Business.TipoDiaComponent business = new Business.TipoDiaComponent();

		public List<TipoDia> GetAll()
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

		public TipoDia GetById(int? id)
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

		public void Add(TipoDia tpoDia)
		{
			try
			{
				business.Add(tpoDia);
			}
			catch
			{
				throw;
			}
		}

		public void Edit(TipoDia tpoDia)
		{
			try
			{
				business.Edit(tpoDia);
			}
			catch
			{
				throw;
			}
		}

		public void Remove(TipoDia tpoDia)
		{
			try
			{
				business.Remove(tpoDia);
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
