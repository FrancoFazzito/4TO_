namespace BE
{
    public class Usuario_Permiso
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
    }

}