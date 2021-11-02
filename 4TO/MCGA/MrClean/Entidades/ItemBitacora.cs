using System;

namespace Entidades
{
    public class ItemBitacora
    {
        public ItemBitacora()
        {
        }

        public ItemBitacora(string mensaje, TipoEvento tipoEvento, string nombreUsuario)
        {
            Fecha = DateTime.Now;
            Mensaje = mensaje;
            TipoEvento = tipoEvento;
            NombreUsuario = nombreUsuario ?? "Test";
        }

        public override string ToString()
        {
            return $"Fecha: {Fecha}, TipoEvento: {TipoEvento}, Mensaje: {Mensaje}, Usuario: {NombreUsuario}";
        }

        public DateTime Fecha { get; set; }
        public string Mensaje { get; set; }
        public TipoEvento TipoEvento { get; set; }
        public string NombreUsuario { get; set; }
    }
}