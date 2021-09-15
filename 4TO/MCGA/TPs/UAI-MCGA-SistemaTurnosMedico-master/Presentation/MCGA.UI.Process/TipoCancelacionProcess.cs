using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCGA.Entities;

namespace MCGA.UI.Process
{
	public class TipoCancelacionProcess : IDisposable
	{
		private Business.TipoCancelacionComponent business = new Business.TipoCancelacionComponent();

		public List<TipoCancelacion> GetAll()
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

		public TipoCancelacion GetById(int? id)
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

		public void Add(TipoCancelacion tipoCancelacion)
		{
			try
			{
				business.Add(tipoCancelacion);
			}
			catch
			{
				throw;
			}
		}

		public void Edit(TipoCancelacion tipoCancelacion)
		{
			try
			{
				business.Edit(tipoCancelacion);
			}
			catch
			{
				throw;
			}
		}

		public void Remove(TipoCancelacion tipoCancelacion)
		{
			try
			{
				business.Remove(tipoCancelacion);
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
