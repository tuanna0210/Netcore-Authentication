using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Data
{
    public class NetCoreIdentityDbContext : IdentityDbContext
    {
        public NetCoreIdentityDbContext(DbContextOptions<NetCoreIdentityDbContext> options) : base(options) { }
    }
}
