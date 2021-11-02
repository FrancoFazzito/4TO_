using Database;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositorio
{
    public class UsuarioRepositorio : SqlDbReadonly<Usuario>, IDigitoVerificador
    {
        private readonly RolRepositorio _rolRepositorio;

        public UsuarioRepositorio()
        {
            _rolRepositorio = new RolRepositorio();
        }

        protected override string SelectAllQuery => "SELECT * FROM Usuario";

        protected override Func<DatabaseRow, Usuario> NewRow => row => new Usuario()
        {
            Id = row.GetValue<int>("Id"),
            Email = row.GetValue<string>("Email"),
            PassSalted = new HashSalt()
            {
                PassHashed = row.GetValue<string>("Pass"),
                Salt = row.GetValue<string>("Salt"),
            },
            Rol = _rolRepositorio.ObtenerTodos().FirstOrDefault(r => r.Id == row.GetValue<int>("rol"))
        };

        public List<Usuario> ObtenerTodos()
        {
            return GetAll().ToList();
        }

        public Usuario ObtenerUsuarioPorMail(string email)
        {
            return GetAll().FirstOrDefault(u => u.Email == email);
        }

        public Usuario ObtenerUsuarioPorMail(int id)
        {
            return GetAll().FirstOrDefault(u => u.Id == id);
        }

        public void AltaUsuario(Usuario usuario, HashSalt passwordHashed, string digitoVerificador)
        {
            _database.NonQuery("INSERT INTO Usuario VALUES (@email,@pass,@salt,@rol,@digito,@activo)")
                     .WithParam("email", usuario.Email)
                     .WithParam("pass", passwordHashed.PassHashed)
                     .WithParam("salt", passwordHashed.Salt)
                     .WithParam("rol", usuario.Rol.Id)
                     .WithParam("digito", digitoVerificador)
                     .WithParam("activo", true)
                     .Execute();
        }

        public void DesactivarUsuario(string mail)
        {
            throw new NotImplementedException();
        }

        public void ActualizarDigitoVertical(string digitoVertical)
        {
            _database.NonQuery("UPDATE DigitoVertical SET DigitoVerificadorVertical = @digitoVerificador WHERE NombreTabla = @nombre")
                     .WithParam("nombre", "usuario")
                     .WithParam("digitoVerificador", digitoVertical)
                     .Execute();
        }

        public string ObtenerDigitoHorizontal(int id)
        {
            return _database.Query("SELECT DigitoVerificadorHorizontal FROM Usuario WHERE Id = @id")
                            .WithParam("id", id)
                            .Select(row => row.GetValue<string>("DigitoVerificadorHorizontal"))
                            .FirstOrDefault();
        }

        public string ObtenerDigitoVertical()
        {
            return _database.Query("SELECT DigitoVerificadorVertical FROM DigitoVertical WHERE NombreTabla = 'usuario'")
                            .Select(row => row.GetValue<string>("DigitoVerificadorVertical"))
                            .FirstOrDefault();
        }
    }
}