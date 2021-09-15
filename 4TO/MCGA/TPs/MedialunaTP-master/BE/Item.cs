namespace BE
{
    public class Item
    {
        private Producto _producto;
        public Producto producto
        {
            get
            {
                return _producto;
            }
            set
            {
                _producto = value;
            }
        }

        private int _cantidad;
        public int cantidad
        {
            get
            {
                return _cantidad;
            }
            set
            {
                _cantidad = value;
            }
        }

        private float _precio;
        public float precio
        {
            get
            {
                return _precio;
            }
            set
            {
                _precio = value;
            }
        }
    }

}