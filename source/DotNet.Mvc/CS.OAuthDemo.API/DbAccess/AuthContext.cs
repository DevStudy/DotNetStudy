using Microsoft.AspNet.Identity.EntityFramework;

namespace CS.OAuthDemo.API.DbAccess
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext()
            : base("AuthContext")
        {

        }
    }
}