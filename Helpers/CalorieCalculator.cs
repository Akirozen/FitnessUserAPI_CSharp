using FitnessUserAPI.Models;

namespace FitnessUserAPI.Helpers
{
   public class CalorieCalculator
   {
      public AddUserRequest userDetails;
      public CalorieCalculator( AddUserRequest userDetails )
      {
         this.userDetails = userDetails;
      }

      public double Calculate()
      {

         var (_, _, Age, Gender, Height, Weight, _) = userDetails;

         double calories;

         if ( Gender == "Male" )
         {
            calories = 66.5 + ( 13.75 * Weight ) + ( 5.003 * Height ) - ( 6.75 * Age );
         }
         else
         {
            calories = 655.1 + ( 9.563 * Weight ) + ( 1.805 * Height ) - ( 4.676 * Age );
         }
         return calories;
      }
   }
}
