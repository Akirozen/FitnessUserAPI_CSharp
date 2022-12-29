using FitnessUserAPI.Data;
using FitnessUserAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessUserAPI.Controllers
{
   [ApiController]
   [Route( "/api/[controller]" )]
   public class UsersController: Controller
   {
      private readonly UsersAPIDbContext dbContext;
      public UsersController( UsersAPIDbContext dbContext )
      {
         this.dbContext = dbContext;
      }

      [HttpGet( Name = "GetFitnessUsers" )]
      public async Task<IActionResult> GetUsers()
      {
         try
         {
            return Ok( await dbContext.Users.ToListAsync() );

         }
         catch ( Exception ex )
         {
            return ( IActionResult ) ex;
         }
      }

      [HttpPost]
      public async Task<IActionResult> AddUser( AddUserRequest addUserRequest )
      {

         var (FirstName, LastName, Age, Gender, Height, Weight, IsTrainer) = addUserRequest;

         double calories;

         if ( Gender == "Male" )
         {
            calories = 66.5 + ( 13.75 * Weight ) + ( 5.003 * Height ) - ( 6.75 * Age );
         }
         else
         {
            calories = 655.1 + ( 9.563 * Weight ) + ( 1.805 * Height ) - ( 4.676 * Age );
         }

         var user = new User()

         {
            Id = Guid.NewGuid(),
            FirstName = FirstName,
            LastName = LastName,
            Age = Age,
            Gender = Gender,
            Height = Height,
            Weight = Weight,
            IsTrainer = IsTrainer,
            DailyCalories = calories,
         };
         try
         {

            await dbContext.Users.AddAsync( user );
            await dbContext.SaveChangesAsync();
            return Ok( user );
         }
         catch ( Exception ex )
         {
            return ( IActionResult ) ex;
         }

      }


   }
}
