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

         double calories;
         if ( addUserRequest.Gender == "Male" )
         {
            calories = 66.5 + ( 13.75 * addUserRequest.Weight ) + ( 5.003 * addUserRequest.Height ) - ( 6.75 * addUserRequest.Age );
         }
         else
         {
            calories = 655.1 + ( 9.563 * addUserRequest.Weight ) + ( 1.805 * addUserRequest.Height ) - ( 4.676 * addUserRequest.Age );
         }

         var user = new User()

         {
            Id = Guid.NewGuid(),
            FirstName = addUserRequest.FirstName,
            LastName = addUserRequest.LastName,
            Age = addUserRequest.Age,
            Gender = addUserRequest.Gender,
            Height = addUserRequest.Height,
            Weight = addUserRequest.Weight,
            IsTrainer = addUserRequest.IsTrainer,
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
