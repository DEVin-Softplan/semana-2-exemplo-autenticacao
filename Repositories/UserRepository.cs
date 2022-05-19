using System.Collections.Generic;
using System.Linq;
using autenticacao.Models;

namespace autenticacao.Repositories
{

    public static class UserRepository
    {
        public static User VerificarUsuarioESenha(string username, string password)
        {
            var users = new List<User>();

            users.Add(new User() { Id = 1, Username = "Vitor", Password = "123", Role = "funcionario" });
            users.Add(new User() { Id = 2, Username = "Cris", Password = "123", Role = "gerente" });

            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == password)
            .FirstOrDefault();
        }
    }
}