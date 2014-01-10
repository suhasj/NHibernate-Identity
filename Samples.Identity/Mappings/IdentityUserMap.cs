using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;


namespace Samples.Identity.Mappings
{
    public class IdentityUserMap : ClassMapping<IdentityUser>
    {
        public IdentityUserMap()
        {
            Id(x => x.Id, map => map.Generator(Generators.Identity));

            Property(x => x.UserName);
            Property(x => x.PasswordHash);
            Property(x => x.Email);
            Property(x => x.IsConfirmed, y => y.Type(new NHibernate.Type.BooleanType()));

            Set(x => x.Claims, y =>
            {
                y.Inverse(true);
                y.Lazy(CollectionLazy.NoLazy);
                y.Table("AspNetUserClaims");
                y.Cascade(Cascade.DeleteOrphans);
                y.Key(x => x.Column("UserId"));
            }, mapping => mapping.OneToMany(z => z.Class(typeof(IdentityUserClaim))));
        }
    }
}
