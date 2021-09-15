namespace BE
{
    using System;

    public class Persona : DigitoVerificador
    {
        private string _nombre;
        public string nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
            }
        }

        private string _apellido;
        public string apellido
        {
            get
            {
                return _apellido;
            }
            set
            {
                _apellido = value;
            }
        }

        private string _dni;
        public string dni
        {
            get
            {
                return _dni;
            }
            set
            {
                _dni = value;
            }
        }

        private string _direccion;
        public string direccion
        {
            get
            {
                return _direccion;
            }
            set
            {
                _direccion = value;
            }
        }

        private string _correo;
        public string correo
        {
            get
            {
                return _correo;
            }
            set
            {
                _correo = value;
            }
        }

        public override string verificar()
        {
            throw new NotImplementedException();
        }
    }

}