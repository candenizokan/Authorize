using Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity.Context
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        //bu sınıf context sınıfımdır. ctorda apsettinsden connectionstring lazım

        public ApplicationDbContext(DbContextOptions)
        {

        }
    }
}
