using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using ArtMarket.Entities.Model;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ArtMarket.Data
{
    public partial class ArtistDAC : DataAccessComponent
    {

        public Artist Create(Artist artist)
        {
            const string SQL_STATEMENT =
                "INSERT INTO dbo.Artist ([FirstName], [LastName], [LifeSpan], [Country], [Description], [TotalProducts]) " +
                "VALUES(@FirstName, @LastName, @Country, @Country, @Description, @TotalProducts); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@FirstName", DbType.String, artist.FirstName);
                db.AddInParameter(cmd, "@LastName", DbType.String, artist.LastName);
                db.AddInParameter(cmd, "@LifeSpan", DbType.String, artist.LifeSpan);
                db.AddInParameter(cmd, "@Country", DbType.String, artist.Country);
                db.AddInParameter(cmd, "@Description", DbType.String, artist.Description);
                db.AddInParameter(cmd, "@TotalProducts", DbType.Int32, artist.TotalProducts);

                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime, artist.CreatedOn != DateTime.MinValue ? artist.CreatedOn : DateTime.Now);
                db.AddInParameter(cmd, "@CreatedBy", DbType.String, String.IsNullOrEmpty(artist.CreatedBy) ? "ApiUser" : artist.CreatedBy);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime, artist.ChangedOn != DateTime.MinValue ? artist.CreatedOn : DateTime.Now);
                db.AddInParameter(cmd, "@ChangedBy", DbType.String, String.IsNullOrEmpty(artist.ChangedBy) ? "ApiUser" : artist.ChangedBy);

                artist.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return artist;
        }

        public void UpdateById(Artist artist)
        {
            const string SQL_STATEMENT =
                "UPDATE dbo.Artist " +
                "SET " +
                    "[FirstName]=@FirstName, " +
                    "[LastName]=@LastName, " +
                    "[LifeSpan]=@LifeSpan, " +
                    "[Country]=@Country, " +
                    "[Description]=@Description, " +
                    "[TotalProducts]=@TotalProducts " +
                "WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@FirstName", DbType.String, artist.FirstName);
                db.AddInParameter(cmd, "@LastName", DbType.String, artist.LastName);
                db.AddInParameter(cmd, "@LifeSpan", DbType.String, artist.LifeSpan);
                db.AddInParameter(cmd, "@Country", DbType.String, artist.Country);
                db.AddInParameter(cmd, "@Description", DbType.String, artist.Description);
                db.AddInParameter(cmd, "@TotalProducts", DbType.Int32, artist.TotalProducts);
                db.AddInParameter(cmd, "@Id", DbType.Int32, artist.Id);

                db.ExecuteNonQuery(cmd);
            }
        }


        public void DeleteById(int id)
        {
            const string SQL_STATEMENT = "DELETE dbo.Artist " +
                                         "WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public Artist SelectById(int id)
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [FirstName], [LastName], [LifeSpan], [Country], [Description], [TotalProducts] " +
                "FROM dbo.Artist  " +
                "WHERE [Id]=@Id ";

            Artist artist = null;

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        artist = LoadArtist(dr);
                    }
                }
            }

            return artist;
        }


        public List<Artist> Select()
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [FirstName], [LastName], [LifeSpan], [Country], [Description], [TotalProducts] " +
                "FROM dbo.Artist ";

            List<Artist> result = new List<Artist>();

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Artist artist = LoadArtist(dr);
                        result.Add(artist);
                    }
                }
            }

            return result;
        }


        private Artist LoadArtist(IDataReader dr)
        {
            Artist artist = new Artist();

            artist.Id = GetDataValue<int>(dr, "Id");
            artist.FirstName = GetDataValue<string>(dr, "FirstName");
            artist.LastName = GetDataValue<string>(dr, "LastName");
            artist.LifeSpan = GetDataValue<string>(dr, "LifeSpan");
            artist.Country = GetDataValue<string>(dr, "Country");
            artist.Description = GetDataValue<string>(dr, "Description");
            artist.TotalProducts = GetDataValue<Int32>(dr, "TotalProducts");

            return artist;
        }
    }
}
