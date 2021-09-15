namespace BE
{
    using System;

    public class Permiso
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

        public override string ToString()
        {
            return _descripcion;
        }

        public override bool Equals(object obj)
        {
            try
            {
                if (this.id.Equals(((Permiso)obj).id))
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