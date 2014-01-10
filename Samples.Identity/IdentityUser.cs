using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace Samples.Identity
{
    public class IdentityUser : IUser<int>
    {
        public virtual int Id { get; set; }

        public virtual string UserName { get; set; }

        public virtual string Email { get; set; }

        public virtual string PasswordHash { get; set; }

        public virtual bool IsConfirmed { get; set; }

        public virtual ICollection<IdentityUserClaim> Claims { get; set; }
        public virtual ICollection<IdentityRole> Roles { get; set; }

    }
}
