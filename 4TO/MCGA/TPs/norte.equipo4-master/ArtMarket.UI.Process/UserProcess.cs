using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtMarket.Entities.Model;

namespace ArtMarket.UI.Process
{
    public class UserProcess : ProcessComponent
    {
        public List<User> GetAll()
        {
            var response = HttpGet<List<User>>("/api/user/listar", new Dictionary<string, object>(), MediaType.Json);
            return response;
        }

        public User Login(string email, string password)
        {
            var response = HttpGet<User>("api/user/login", new List<object>() { email, password}, MediaType.Json);
            return response;
        }

        public User Get(int id)
        {
            var response = HttpGet<User>("api/user/buscar", new List<object>() { id }, MediaType.Json);
            return response;
        }

        public User Add(User user)
        {
            var response = HttpPost<User>("api/user/agregar", user, MediaType.Json);
            return response;
        }

        public void Edit(User user)
        {
            HttpPost<User>("api/user/editar", user, MediaType.Json);
        }

        public void Delete(int id)
        {
            HttpDelete<User>("api/user/eliminar", id, MediaType.Json);
        }

    }
}
