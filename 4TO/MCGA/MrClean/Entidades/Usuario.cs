namespace Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public Rol Rol { get; set; }
        public string Pass { get; set; }
        public HashSalt PassSalted { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"{Email.ToLower()}: {Rol.Nombre.ToLower()}";
        }
    }
}