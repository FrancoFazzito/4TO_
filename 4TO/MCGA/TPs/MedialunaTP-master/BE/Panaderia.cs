namespace BE
{
    using System;

    public class Panaderia
    {
        private int _id;
        public int id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

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

        private string _ubicacion;
        public string ubicacion
        {
            get
            {
                return _ubicacion;
            }
            set
            {
                _ubicacion = value;
            }
        }

        public override string ToString()
        {
            return _nombre;
        }

        public override bool Equals(object obj)
        {
            try
            {
                if (this.nombre.Equals(((Panaderia)obj).nombre) && this.ubicacion.Equals(((Panaderia)obj).ubicacion))
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            return this.id.GetHashCode();
        }
    }

}