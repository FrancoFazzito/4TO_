namespace BE
{
    using System.Collections.Generic;

    public class Pedidos
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

        private List<Item> _items;
        public List<Item> items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
            }
        }

        private Panaderia _panaderia;
        public Panaderia panaderia
        {
            get
            {
                return _panaderia;
            }
            set
            {
                _panaderia = value;
            }
        }
    }

}