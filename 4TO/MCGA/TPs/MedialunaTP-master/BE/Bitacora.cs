using System;
using System.Xml;
using System.Xml.Serialization;

namespace BE
{
    [Serializable]
    public class Bitacora : DigitoVerificador
    {
        private Usuario _usuario;
        public Usuario usuario
        {
            get
            {
                return _usuario;
            }
            set
            {
                _usuario = value;
            }
        }
        private string _accion;
        public string accion
        {
            get
            {
                return _accion;
            }
            set
            {
                _accion = value;
            }
        }
        private DateTime _fecha;
        public DateTime fecha
        {
            get
            {
                return _fecha;
            }
            set
            {
                _fecha = value;
            }
        }
        public override string verificar()
        {
            string usr = "";
            if (usuario != null)
                usr = usuario.ToString();
            return usr + accion + fecha.ToString("dd/MM/yyyy H:mm:ss");
        }
    }
}