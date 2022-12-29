using FitnessUserAPI.Data;
using FitnessUserAPI.Helpers;
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
            return BadRequest( ex );
         }
      }

      [HttpGet]
      [Route( "{id:guid}" )]
      public async Task<IActionResult> GetUser( [FromRoute] Guid id )
      {
         try
         {
            var user = await dbContext.Users.FindAsync( id );

            if ( user == null )
            {
               return NotFound();
            }
            return Ok( user );

         }
         catch ( Exception ex )
         {
            return BadRequest( ex );
         }
      }

      [HttpPost( Name = "AddFitnessUsers" )]
      public async Task<IActionResult> AddUser( AddUserRequest addUserRequest )
      {
         var (FirstName, LastName, Age, Gender, Height, Weight, IsTrainer) = addUserRequest;

         var calorieCalculate = new CalorieCalculator( addUserRequest );

         double calories = calorieCalculate.Calculate();

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
            return BadRequest( ex );
         }

      }

      [HttpDelete]
      [Route( "{id:guid}" )]
      public async Task<IActionResult> DeleteUser( [FromRoute] Guid id )
      {
         try
         {
            var user = await dbContext.Users.FindAsync( id );

            if ( user == null )
            {
               return NotFound();
            };

            dbContext.Remove( user );
            await dbContext.SaveChangesAsync();
            return Ok( user );
         }
         catch ( Exception ex )
         {
            return BadRequest( ex );
         }
      }
   }
}
