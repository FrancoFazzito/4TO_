using MCGA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA.UI.Process
{
	public class AfiliadoProcess : IDisposable
	{
		private Business.AfiliadoComponent business = new Business.AfiliadoComponent();

		public List<Afiliado> GetAll()
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

		public Afiliado GetById(int? id)
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

		public void Add(Afiliado afiliado)
		{
			try
			{
				business.Add(afiliado);
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
				business.Edit(afiliado);
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
				business.Remove(afiliado);
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
