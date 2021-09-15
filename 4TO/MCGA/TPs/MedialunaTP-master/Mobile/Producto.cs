namespace Mobile
{
    using System;

    public class Producto
    {
        public int ID { get; set; }
        public string descripcion { get; set; }
        public string imagen { get; set; }

       
        public override string ToString()
        {
            return descripcion;
        }

        public override bool Equals(object obj)
        {
            try
            {
                if (this.ID.Equals(((Producto)obj).ID))
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
            return this.ID.GetHashCode();
        }
    }

}