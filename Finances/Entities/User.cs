using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Finances.Entities
{
    public class User
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Informe o nome do Usuário")]
        public string name { get; set; }

        [Required(ErrorMessage = "Informe o email do Usuário"), EmailAddress(ErrorMessage = "Email do Usuário inválido")]
        public string email { get; set; }
    }
}