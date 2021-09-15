using BE;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class PanaderiasDAL
    {
        public static List<Panaderia> Listar()
        {
            var lista = new List<Panaderia>();
            Acceso acceso = new Acceso();
            DataTable tabla = acceso.leer("panaderia_leer", null);
            foreach (DataRow item in tabla.Rows)
            {
                Panaderia obj = new Panaderia();
                obj.id = int.Parse(item["id"].ToString());
                obj.nombre = item["nombre"].ToString();
                obj.ubicacion = item["ubicacion"].ToString();
                lista.Add(obj);
            }
            return lista;
        }

        public static int baja(Panaderia param)
        {
            return 0;
        }

        public static int Insertar(Panaderia param)
        {
            return 0;
        }

        public static int Modificar(Panaderia param)
        {
            return 0;
        }

        public static Panaderia Buscar(Panaderia param)
        {
            var lista = Listar();
            int encontro = lista.IndexOf(param);
            if (encontro != -1)
                return lista[encontro];
            else
                return null;
        }
    }
}