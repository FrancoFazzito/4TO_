namespace Domain
{
    public class ClientCreated : IDomainEvent<Client>
    {
        public ClientCreated(Client param)
        {
            Args = param;
        }

        public Client Args { get; }
    }
}