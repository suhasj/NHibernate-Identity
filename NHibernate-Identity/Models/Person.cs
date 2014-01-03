using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernate_Identity.Models
{
    public class Person
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
    }
}