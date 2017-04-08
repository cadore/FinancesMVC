using EFHelpers;
using Finances.DAO;
using Finances.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace System.ComponentModel.DataAnnotations
{
    class Unique : ValidationAttribute
    {

        public bool New { get; set; }
        public Object obj { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var db = new FinancesContext();

            Object obj = validationContext.ObjectType;
            System.Diagnostics.Debug.WriteLine(obj.ToString());

            var className = obj.ToString().Split('.').Last();
            var propertyName = validationContext.MemberName;
            var parameterName = string.Format("@{0}", propertyName);
            
            
            var sql = string.Format("SELECT COUNT(*) FROM {0} WHERE {1}={2}", 
                className.ToLower() + "s", propertyName, parameterName);
            var parameters = new Npgsql.NpgsqlParameter(parameterName, value);

            var result = db.Database.SqlQuery<Int64>(sql, parameters).Single();
            if (result > 0)
            {
                return new ValidationResult(String.Format(ErrorMessage, value), new List<string>() { propertyName });
            }

            return null;
        }
    }
}