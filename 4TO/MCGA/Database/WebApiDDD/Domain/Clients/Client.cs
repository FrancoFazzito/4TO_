using System;

namespace Domain
{
    public class Client : IEntity
    {
        //named constructor
        public static IDomainEvent<Client> Create(int id, ClientName name)
        {
            return new ClientCreated(new Client()
            {  
                Id = id,
                Name = name,
                CreatedDate = DateTime.Now
            });
        }

        public double GetWalletAmount() //tell don't ask - reduce chain method
        {
            return Wallet.Amount;
        }

        public int Id { get; set; }

        public ClientName Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public ClientWallet Wallet { get; set; }
    }

    //client
        //id -> Primitive
        //clientName -> VO
        //wallet -> VO
        //
}