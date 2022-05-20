using System.Collections.Generic;
using System.Linq;
using autenticacao.Enums;
using autenticacao.Models;

namespace autenticacao.Repositories
{

    public static class UserRepository
    {
        public static User VerificarUsuarioESenha(string username, string password)
        {
            var users = new List<User>();

            users.Add(new User() { Id = 1, Username = "Vitor", Password = "123", Role = "funcionario", Permissao = Permissoes.Funcionario});
            users.Add(new User() { Id = 2, Username = "Cris", Password = "123", Role = "gerente", Permissao = Permissoes.Gerente});

            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == password)
            .FirstOrDefault();
        }
        public static List<User> Obter()
        {
            var users = new List<User>();

            users.Add(new User() { Id = 1, Username = "Vitor", Password = "123", Role = "funcionario", Permissao = Permissoes.Funcionario});
            users.Add(new User() { Id = 2, Username = "Cris", Password = "123", Role = "gerente", Permissao = Permissoes.Gerente});

            return users;
        }
    }
}