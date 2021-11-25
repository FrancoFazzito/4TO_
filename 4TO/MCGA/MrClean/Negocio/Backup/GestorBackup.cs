using Repositorio;

namespace Negocio
{
    public class GestorBackup
    {
        private readonly ServicioBackup servicioBackup;

        public GestorBackup()
        {
            servicioBackup = new ServicioBackup();
        }

        public void GuardarBackup()
        {
            servicioBackup.Backup();
        }

        public void Restaurar()
        {
            servicioBackup.Restaurar();
        }

        public string RutaBackup => servicioBackup.RutaBackup;
    }
}