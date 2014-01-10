using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using NHibernate;

namespace Samples.Identity
{
    public class NHibernateUserStore<TUser> : IUserStore<TUser, int>, IUserPasswordStore<TUser, int> where TUser : IdentityUser
    {
        private static Task nopTask = Task.FromResult(0);

        public Task CreateAsync(TUser user)
        {
            using (var session = NHibernateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(user);
                    transaction.Commit();
                }
            }

            return nopTask;
        }

        public Task DeleteAsync(TUser user)
        {
            using (var session = NHibernateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(user);
                    transaction.Commit();
                }
            }

            return nopTask;
        }

        public Task<TUser> FindByIdAsync(int userId)
        {
            using (var session = NHibernateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    return Task.FromResult(session.Load<TUser>(userId));
                }
            }
        }

        public Task<TUser> FindByNameAsync(string userName)
        {
            using (var session = NHibernateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var user = session.CreateQuery("from IdentityUser u where u.UserName=:username").
                        SetString("username", userName).
                        List<TUser>().FirstOrDefault();

                    return Task.FromResult(user);
                }
            }
        }

        public Task UpdateAsync(TUser user)
        {
            using (var session = NHibernateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(user);
                    transaction.Commit();
                }
            }
            return nopTask;
        }

        public void Dispose()
        {

        }

        public Task<string> GetPasswordHashAsync(TUser user)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(TUser user)
        {
            return String.IsNullOrEmpty(user.PasswordHash) ? Task.FromResult(false) : Task.FromResult(true);
        }

        public Task SetPasswordHashAsync(TUser user, string passwordHash)
        {
            user.PasswordHash = passwordHash;
            return Task.FromResult(0);
        }
    }
}
