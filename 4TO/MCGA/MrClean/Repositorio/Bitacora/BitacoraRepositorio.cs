using Database;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositorio
{
    public class BitacoraRepositorio : SqlDbReadonly<ItemBitacora>
    {
        protected override string SelectAllQuery => "SELECT * FROM Bitacora";

        protected override Func<DatabaseRow, ItemBitacora> NewRow => row => new ItemBitacora()
        {
            Mensaje = row.GetValue<string>("mensaje"),
            TipoEvento = EnumParser<TipoEvento>.GetEnum(row.GetValue<string>("tipo")),
            NombreUsuario = row.GetValue<string>("usuario"),
            Fecha = row.GetValue<DateTime>("fecha")
        };

        public void Registrar(ItemBitacora itemBitacora)
        {
            _database.NonQuery("INSERT INTO Bitacora VALUES (@fecha,@mensaje,@tipo,@usuario)")
                     .WithParam("fecha", itemBitacora.Fecha)
                     .WithParam("mensaje", itemBitacora.Mensaje.ToString())
                     .WithParam("tipo", itemBitacora.TipoEvento)
                     .WithParam("usuario", itemBitacora.NombreUsuario)
                     .Execute();
        }

        public List<ItemBitacora> GetItems()
        {
            return GetAll().ToList();
        }
    }
}