using System.ComponentModel.DataAnnotations;

namespace autenticacao.Enums
{
    public enum Permissoes
    {
        [Display(Name = "Funcionário")]
        Funcionario = 1,
        [Display(Name = "Gerente")]
        Gerente,
        [Display(Name = "Administrador")]
        Adm
    }
}