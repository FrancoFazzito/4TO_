using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using ArtMarket.Entities.Model;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ArtMarket.Data
{
    // Todo esto queda deprecado si utilizamos login de Owin
    public class UserDAC : DataAccessComponent
    {
        public User Create(User user)
        {
            const string SQL_STATEMENT =
                "INSERT INTO dbo.[User] ([FirstName], [LastName], [Email], [Password], [City], [Country]) " +
                "VALUES(@FirstName, @LastName, @Email, @Password, @City, @Country); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@FirstName", DbType.String, user.FirstName);
                db.AddInParameter(cmd, "@LastName", DbType.String, user.LastName);
                db.AddInParameter(cmd, "@Email", DbType.String, user.Email);
                db.AddInParameter(cmd, "@City", DbType.String, user.City);
                db.AddInParameter(cmd, "@Country", DbType.String, user.Country);

                user.Id = (int) db.ExecuteScalar(cmd);
            }

            return user;
        }


        public List<User> Select()
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [FirstName], [LastName], [Email], [Password], [City], [Country] " +
                "FROM dbo.[User] ";

            List<User> result = new List<User>();

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        User user = LoadUser(dr);
                        result.Add(user);
                    }
                }
            }

            return result;
        }

        private User LoadUser(IDataReader dr)
        {
            User user = new User();

            user.Id = GetDataValue<int>(dr, "Id");
            user.FirstName = GetDataValue<string>(dr, "FirstName");
            user.LastName = GetDataValue<string>(dr, "LastName");
            user.Email = GetDataValue<string>(dr, "Email");
            user.City = GetDataValue<string>(dr, "City");
            user.Country = GetDataValue<string>(dr, "Country");

            return user;
        }

        public User Login(string usr, string psw)
        {
            const string SQL_STATEMENT =
                "SELECT [IdUsuario], [NombreUsuario], [Contraseña], [Nombre], [Apellido],[DNI], [FechaNacimiento], [FechaCreacion], IdTipoUsuario " +
                "FROM dbo.Users " +
                "WHERE [NombreUsuario]=@usr AND [Contraseña]= @psw ";

            User user = null;

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@usr", DbType.String, usr);
                db.AddInParameter(cmd, "@psw", DbType.String, psw);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        user = LoadUser(dr);
                    }
                }
            }

            return user;
        }
    }
}
