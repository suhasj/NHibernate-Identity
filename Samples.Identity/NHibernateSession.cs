using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Samples.Identity
{
    public class NHibernateSession
    {
        public static ISession OpenSession()
        {
            var configuration = new Configuration();
            var configurationPath = HttpContext.Current.Server.MapPath(@"~\hibernate.cfg.xml");
            configuration.Configure(configurationPath);
            configuration.AddFile(HttpContext.Current.Server.MapPath(@"~\Mappings\IdentityUser.hbm.xml"));
            configuration.AddFile(HttpContext.Current.Server.MapPath(@"~\Mappings\IdentityRole.hbm.xml"));
            configuration.AddFile(HttpContext.Current.Server.MapPath(@"~\Mappings\IdentityUserClaim.hbm.xml"));
            //configuration.AddFile(HttpContext.Current.Server.MapPath(@"~\Mappings\IdentityUserLogin.hbm.xml"));
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}