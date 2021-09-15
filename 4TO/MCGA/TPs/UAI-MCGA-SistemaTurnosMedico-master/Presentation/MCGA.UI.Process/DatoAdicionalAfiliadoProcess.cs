using MCGA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MCGA.UI.Process
{
	public class DatoAdicionalAfiliadoProcess : IDisposable
	{
		private Business.DatoAdicionalAfiliadoComponent business = new Business.DatoAdicionalAfiliadoComponent();

		

		public List<DatoAdicionalAfiliado> GetAll()
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

		public DatoAdicionalAfiliado GetById(int? id)
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

		public void GuardarDatoAdicional(List<DatoAdicionalAfiliado> listDatoAdicionalAfiliado)
		{
			try
			{
				using (TransactionScope scope = new TransactionScope())
				{
					foreach (DatoAdicionalAfiliado datoAdicionalAfiliado in listDatoAdicionalAfiliado)
					{
						var datoAdicionalAfiliadoExistente = business.GetAll().Where(o => o.AfiliadoId == datoAdicionalAfiliado.AfiliadoId && o.TipoKeyId == datoAdicionalAfiliado.TipoKeyId).FirstOrDefault();
						datoAdicionalAfiliado.Fecha = DateTime.Now;
						if(datoAdicionalAfiliadoExistente == null)
							business.Add(datoAdicionalAfiliado);
						else
						{
							datoAdicionalAfiliadoExistente.Fecha = datoAdicionalAfiliado.Fecha;
							datoAdicionalAfiliadoExistente.JsonData = datoAdicionalAfiliado.JsonData;
							business.Edit(datoAdicionalAfiliadoExistente);
						}
							
					}
					scope.Complete();
				}
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
				business.Add(datoAdicionalAfiliado);
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
				business.Edit(datoAdicionalAfiliado);
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
