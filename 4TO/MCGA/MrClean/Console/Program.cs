using Entidades;
using Negocio;

namespace Console
{
    public class Program
    {
        private static void Main(string[] args)
        {
            CrearDatos();
            var gestorDigitoVertical = new GestorDigitoVerificadorVertical();
            var valido = gestorDigitoVertical.EsValido();
        }

        private static void CrearDatos()
        {
            var login = new GestorUsuario();
            login.AltaUsuario(new Usuario()
            {
                Email = "franco@gmail.com",
                Pass = "123456Aa",
                Rol = new Rol()
                {
                    Nombre = "cliente",
                    Id = 2
                }
            });
            login.AltaUsuario(new Usuario()
            {
                Email = "vilu@gmail.com",
                Pass = "123456Aa",
                Rol = new Rol()
                {
                    Nombre = "cliente",
                    Id = 2
                }
            });
            login.AltaUsuario(new Usuario()
            {
                Email = "katia@gmail.com",
                Pass = "123456Aa",
                Rol = new Rol()
                {
                    Nombre = "master",
                    Id = 1
                }
            });
            login.AltaUsuario(new Usuario()
            {
                Email = "tomas@gmail.com",
                Pass = "123456Aa",
                Rol = new Rol()
                {
                    Nombre = "operador",
                    Id = 3
                }
            });
            login.AltaUsuario(new Usuario()
            {
                Email = "nelson@gmail.com",
                Pass = "123456Aa",
                Rol = new Rol()
                {
                    Nombre = "gerente",
                    Id = 4
                }
            });
            login.Login("katia@gmail.com", "123456Aa");

            var producto = new GestorProducto();
            producto.AltaProducto(new Producto()
            {
                Nombre = "Trapo de piso",
                Precio = 50.00m,
                RutaImagen = "Imagenes/trapo.jpg"
            });

            producto.AltaProducto(new Producto()
            {
                Nombre = "jabon",
                Precio = 100.00m,
                RutaImagen = "Imagenes/jabon.jpg"
            });

            producto.AltaProducto(new Producto()
            {
                Nombre = "Detergente",
                Precio = 150.00m,
                RutaImagen = "Imagenes/detergente.jpg"
            });

            producto.AltaProducto(new Producto()
            {
                Nombre = "shampoo",
                Precio = 200.00m,
                RutaImagen = "Imagenes/shampoo.jpg"
            });
        }
    }
}