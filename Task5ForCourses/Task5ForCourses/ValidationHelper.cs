using System;

namespace Task5ForCourses
{
	public class ValidationHelper
	{
		public static string GetValidDescription()
		{
			Console.WriteLine($"{Environment.NewLine}Please, enter description for your task:");

			var inputValue = Console.ReadLine();

			while (String.IsNullOrWhiteSpace(inputValue))
			{
				Console.WriteLine($"Entered value is null or empty.{Environment.NewLine}Please, re-enter valid description for your task:");
				inputValue = Console.ReadLine();
			}
			return inputValue;
		}

		public static int GetValidDays()
		{
			string inputValue = GetValueNotNullOrEmpty();
			int validatedValue;
			while (!int.TryParse(inputValue, out validatedValue) || validatedValue <= 0)
			{
				Console.Clear();
				Console.WriteLine($"Entered value is invalid.{Environment.NewLine}Please re-enter number of days. It`s need for you will see your tasks that can be completed in a given number of days (considering {Constants.WorkingHoursPerDay} working hours per day).");
				inputValue = GetValueNotNullOrEmpty();
			}
			return validatedValue;
		}

		public static string GetValueNotNullOrEmpty()
		{
			var inputValue = Console.ReadLine();

			while (String.IsNullOrWhiteSpace(inputValue))
			{
				Console.Clear();
				Console.WriteLine($"Entered value is null or empty.{Environment.NewLine}Please re-enter number of days. It`s need for you will see your tasks that can be completed in a given number of days (considering {Constants.WorkingHoursPerDay} working hours per day).");
				inputValue = Console.ReadLine();
			}
			return inputValue;
		}
	}
}
