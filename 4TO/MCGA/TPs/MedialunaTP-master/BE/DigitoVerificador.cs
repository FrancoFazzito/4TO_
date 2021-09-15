namespace BE
{
    public abstract class DigitoVerificador
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

        private string _DVH;
        public string DVH
        {
            get
            {
                return _DVH;
            }
            set
            {
                _DVH = value;
            }
        }

        public abstract string verificar();
    }

}