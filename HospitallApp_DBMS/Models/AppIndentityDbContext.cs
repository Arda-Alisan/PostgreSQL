using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HospitallApp_DBMS.Models {
    public class AppIdentityDbContext : IdentityDbContext<IdentityUser> {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options): base(options) {

         }
    }
}