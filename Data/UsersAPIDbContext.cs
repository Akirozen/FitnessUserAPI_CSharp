using FitnessUserAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessUserAPI.Data
{
   public class UsersAPIDbContext: DbContext
   {
      public UsersAPIDbContext( DbContextOptions options ) : base( options )
      {

      }

      public DbSet<User> Users { get; set; }
   }
}
