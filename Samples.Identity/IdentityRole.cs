using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using Microsoft.AspNet.Identity;

namespace Samples.Identity
{
    public class IdentityRole:IRole<int>
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual ICollection<IdentityUser> Users { get; set; }
    }
    
}
