using Finances.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finances.DAO
{
    public class UserDAO
    {
        private FinancesContext context;

        public UserDAO(FinancesContext context)
        {
            this.context = context;
        }
        public void Save(User us)
        {
            if(us.id == 0)
                context.Users.Add(us);
            else
            {
                context.Users.Attach(us);
                context.Entry(us).State = System.Data.Entity.EntityState.Modified;
            }
            context.SaveChanges();
            Console.WriteLine(us.id);
        }

        public IList<User> List()
        {
            return (from p in context.Users orderby p.id select p).ToList();
        }

        public User Details(int? id)
        {
            return context.Users.Find(id);
        }
    }
}