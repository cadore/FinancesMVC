using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Finances.Entities
{
    [Table("transactions")]
    public class Transaction
    {
        public int id { get; set; }

        [Required]
        public decimal value { get; set; }

        public DateTime date { get; set; }

        public TypeTransaction type { get; set; }

        public int userId { get; set; }

        public virtual User user { get; set; }
    }

    public enum TypeTransaction
    {
        Input, Output
    }
}