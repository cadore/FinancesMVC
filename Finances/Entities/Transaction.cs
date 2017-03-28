using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finances.Entities
{

    public class Transaction
    {
        public int id { get; set; }

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