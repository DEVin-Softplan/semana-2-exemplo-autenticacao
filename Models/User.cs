using autenticacao.Enums;
using Microsoft.OpenApi.Extensions;

namespace autenticacao.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public Permissoes Permissao { get; set; }
        public string DescricaoPermissao => Permissao.GetDisplayName();
    }
}