using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Finances.Entities
{
    [Table("users")]
    public class User
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Informe o nome do Usuário")]
        public string name { get; set; }

        [Required(ErrorMessage = "Informe o Login do Usuário")/*,
        Unique(ErrorMessage = "O login '{0}' ja esta cadastrado para outro usuário")*/]
        public string login { get; set; }

        [Required(ErrorMessage = "Informe o email do Usuário"), 
        EmailAddress(ErrorMessage = "Email do Usuário inválido")]
        public string email { get; set; }
    }
}