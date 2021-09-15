namespace BE
{
    public class DigitoVerificadorVertical : DigitoVerificador
    {
        private string _tabla;
        public string tabla
        {
            get
            {
                return _tabla;
            }
            set
            {
                _tabla = value;
            }
        }

        private string _dvv;
        public string DVV
        {
            get
            {
                return _dvv;
            }
            set
            {
                _dvv = value;
            }
        }

        public override string verificar()
        {
            return tabla + DVV;
        }
    }

}