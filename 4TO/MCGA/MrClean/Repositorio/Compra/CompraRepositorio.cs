using Database;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositorio
{
    public class CompraRepositorio : SqlDbReadonly<Compra>
    {
        private readonly UsuarioRepositorio _usuarioRepositorio;

        public CompraRepositorio()
        {
            _usuarioRepositorio = new UsuarioRepositorio();
        }

        protected override string SelectAllQuery => "SELECT * FROM Compra";

        protected override Func<DatabaseRow, Compra> NewRow => row => new Compra()
        {
            Id = row.GetValue<int>("id"),
            Codigo = row.GetValue<string>("codigo"),
            Total = row.GetValue<decimal>("total"),
            Entregado = row.GetValue<bool>("entregado"),
            Usuario = _usuarioRepositorio.ObtenerUsuarioPorMail(row.GetValue<int>("Usuario")).Email
        };

        public List<Compra> ObtenerCompras()
        {
            return GetAll().ToList();
        }

        public void RegistrarCompra(Compra compra, string codigo, string direccion)
        {
            var commandCompra = _database.NonQuery("INSERT INTO Compra VALUES (@total,@codigo,@entregada,@usuario,@direccion)")
                                         .WithParam("total", compra.CalcularTotal())
                                         .WithParam("codigo", codigo)
                                         .WithParam("entregada", compra.Entregado)
                                         .WithParam("usuario", _usuarioRepositorio.ObtenerUsuarioPorMail(compra.Usuario).Id)
                                         .WithParam("direccion", direccion);

            var transaction = _database.Transaction()
                                       .AddCommand(commandCompra);

            foreach (var producto in compra.Productos)
            {
                transaction.AddCommand(_database.NonQuery("INSERT INTO CompraProducto VALUES ((SELECT IDENT_CURRENT('Compra')), @Producto)")
                                                .WithParam("Producto", producto.Id));
                transaction.AddCommand(_database.NonQuery("UPDATE Producto SET stock = stock - 1 WHERE Id = @id")
                                                .WithParam("id", producto.Id));
            }

            transaction.Execute();
        }
    }
}