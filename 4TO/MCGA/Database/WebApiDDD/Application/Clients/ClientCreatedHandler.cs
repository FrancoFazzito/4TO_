using Domain;
using System;

namespace Application
{
    public class ClientCreatedHandler : IHandler<ClientCreated>
    {
        public void Handle(ClientCreated eventToHandle)
        {
            //send email
            Console.WriteLine($"Email sended to: {eventToHandle.Args.Name}");
            
            //register newsletter
            Console.WriteLine($"{eventToHandle.Args.Name} registered in newsletter");

            //register to offer
            Console.WriteLine($"{eventToHandle.Args.Name} registered to offer");
        }
    }
}