namespace BE
{
    using System;

    public class Producto : DigitoVerificador
    {
        private string _descripcion;
        public string descripcion
        {
            get
            {
                return _descripcion;
            }
            set
            {
                _descripcion = value;
            }
        }

        private string _imagen;
        public string imagen
        {
            get
            {
                return _imagen;
            }
            set
            {
                _imagen = value;
            }
        }

        public override string ToString()
        {
            return _descripcion;
        }

        public override bool Equals(object obj)
        {
            try
            {
                if (this.id.Equals(((Producto)obj).id))
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

        public override string verificar()
        {
            return descripcion + imagen;
        }
    }

}