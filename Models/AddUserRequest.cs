namespace FitnessUserAPI.Models
{
   public class AddUserRequest
   {
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public int Age { get; set; }
      public string Gender { get; set; }

      public float Height { get; set; }
      public float Weight { get; set; }
      public bool IsTrainer { get; set; }
      public double DailyCalories { get; set; }
   }
}
