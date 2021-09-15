namespace DAL
{
    public class backupDAL
    {
        public static string hacerBackup()
        {
            Acceso acceso = new Acceso();
            System.IO.Directory.CreateDirectory("c:\back");
            string sql = @"backup database Medialunas to disk='c:\back\backup.sql'";
            acceso.abrir();
            int afectadas = acceso.ejecutarSQL(sql, null);
            acceso.cerrar();
            return afectadas.ToString();
        }

        public static string restaurarBackup()
        {
            Acceso acceso = new Acceso();
            string antes = "alter database Medialunas set offline with rollback immediate";
            string despues = "alter database Medialunas set online";
            string sql = @"restore database Medialunas from disk='c:\back\backup.sql'";
            acceso.abrir();
            int antesI = acceso.ejecutarSQL(antes, null);
            int afectadas = acceso.ejecutarSQL(sql, null);
            int despuesI = acceso.ejecutarSQL(despues, null);
            acceso.cerrar();
            return "Antes: " + antesI + " Restore: " + afectadas + " Despues: " + despuesI;
        }
    }

}