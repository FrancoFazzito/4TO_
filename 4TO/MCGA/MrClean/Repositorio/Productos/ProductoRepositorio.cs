using Database;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositorio
{
    public class ProductoRepositorio : SqlDbReadonly<Producto>, IDigitoVerificador
    {
        protected override string SelectAllQuery => "Select * from producto";

        protected override Func<DatabaseRow, Producto> NewRow => row => new Producto()
        {
            Id = row.GetValue<int>("Id"),
            Nombre = row.GetValue<string>("Nombre"),
            Precio = row.GetValue<decimal>("Precio"),
            RutaImagen = row.GetValue<string>("rutaImagen"),
            Stock = row.GetValue<int>("Stock")
        };

        public Producto ObtenerPorId(int id)
        {
            return GetAll().First(c => c.Id == id);
        }

        public Producto ObtenerPorNombre(string nombre)
        {
            return GetAll().First(c => c.Nombre == nombre);
        }

        public List<Producto> ObtenerTodos()
        {
            return GetAll().ToList();
        }

        public void AltaProducto(Producto producto, string digitoVerificador)
        {
            _database.NonQuery("INSERT INTO Producto VALUES (@nombre,@precio,@rutaImagen,@digitoVerificador,@stock)")
                     .WithParam("nombre", producto.Nombre)
                     .WithParam("precio", producto.Precio)
                     .WithParam("rutaImagen", producto.RutaImagen)
                     .WithParam("digitoVerificador", digitoVerificador)
                     .WithParam("stock", producto.Stock)
                     .Execute();
        }

        public void ActualizarDigitoVertical(string digitoVertical)
        {
            _database.NonQuery("UPDATE DigitoVertical SET DigitoVerificadorVertical = @digitoVerificador WHERE NombreTabla = @nombre")
                     .WithParam("nombre", "producto")
                     .WithParam("digitoVerificador", digitoVertical)
                     .Execute();
        }

        public string ObtenerDigitoHorizontal(int id)
        {
            return _database.Query("SELECT DigitoVerificadorHorizontal FROM Producto WHERE Id = @id")
                            .WithParam("id", id)
                            .Select(row => row.GetValue<string>("DigitoVerificadorHorizontal"))
                            .FirstOrDefault();
        }

        public string ObtenerDigitoVertical()
        {
            return _database.Query("SELECT DigitoVerificadorVertical FROM DigitoVertical WHERE NombreTabla = 'producto'")
                            .Select(row => row.GetValue<string>("DigitoVerificadorVertical"))
                            .FirstOrDefault();
        }
    }
}