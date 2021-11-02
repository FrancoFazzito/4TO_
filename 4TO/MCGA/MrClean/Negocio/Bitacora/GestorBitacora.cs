using Entidades;
using Repositorio;
using System.Collections.Generic;
using System.Linq;

namespace Negocio
{
    public class GestorBitacora
    {
        private readonly BitacoraRepositorio _bitacoraRepositorio;

        public GestorBitacora()
        {
            _bitacoraRepositorio = new BitacoraRepositorio();
        }

        public void Registrar(ItemBitacora itemBitacora)
        {
            _bitacoraRepositorio.Registrar(itemBitacora);
        }

        public List<ItemBitacora> GetItems()
        {
            return _bitacoraRepositorio.GetItems().OrderByDescending(b => b.Fecha).ToList();
        }
    }
}