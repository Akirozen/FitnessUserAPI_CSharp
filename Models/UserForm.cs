namespace FitnessUserAPI.Models
{
   public class UserForm
   {
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public int Age { get; set; }
      public string Gender { get; set; }
      public float Height { get; set; }
      public float Weight { get; set; }
      public bool IsTrainer { get; set; }
      //public double DailyCalories { get; set; }

      public void Deconstruct( out string firstName, out string lastName,
         out int age, out string gender, out float height,
         out float weight, out bool isTrainer
         )
      {
         firstName = FirstName;
         lastName = LastName;
         age = Age;
         gender = Gender;
         height = Height;
         weight = Weight;
         isTrainer = IsTrainer;
      }
   }
}
