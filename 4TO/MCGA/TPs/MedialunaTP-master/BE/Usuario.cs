using System.Xml.Serialization;
using System;

namespace BE
{
    [Serializable]
    public class Usuario : Persona
    {
        private string _login;
        public string login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
            }
        }

        private string _pass;
        public string pass
        {
            get
            {
                return _pass;
            }
            set
            {
                _pass = value;
            }
        }

        private bool _habilitado;
        public bool habilitado
        {
            get
            {
                return _habilitado;
            }
            set
            {
                _habilitado = value;
            }
        }

        private int _intentosLogin;
        public int intentosLogin
        {
            get
            {
                return _intentosLogin;
            }
            set
            {
                _intentosLogin = value;
            }
        }

        private Permiso _permiso;
        public Permiso permiso
        {
            get
            {
                return _permiso;
            }
            set
            {
                _permiso = value;
            }
        }

        public override string ToString()
        {
            return this.nombre + " " + this.apellido;
        }

        public override bool Equals(object obj)
        {
            try
            {
                if (this.login.Equals(((Usuario)obj).login) && this.pass.Equals(((Usuario)obj).pass))
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override string verificar()
        {
            return login + pass + nombre + apellido + correo;
        }

        public override int GetHashCode()
        {
            return this.id.GetHashCode();
        }
    }

}