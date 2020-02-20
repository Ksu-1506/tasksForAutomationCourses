using System;

namespace Task1_2ForCourses
{
	class MathCalc
	{
		private double GetRandomNumberAfter3FailedAttempts()
		{
			Random random = new Random();
			return random.NextDouble() * (Constants.randomMax - Constants.randomMin) + Constants.randomMin;
		}

		public double CheckNotNegativeValueInGetters(string valueName, string figureName)
		{
			for (int i = 1; i <= 3; i++)
			{
				Console.WriteLine($"Please, enter {valueName} of {figureName}: ");
				var enteredUsersValue = Console.ReadLine();
				bool isParsed = double.TryParse(enteredUsersValue, out double validatedUsersValue);
				if (isParsed && validatedUsersValue > 0)
				{
					return Math.Round(validatedUsersValue, 2);
				}

				if (i == 3)
				{
					Console.WriteLine($"You failed all chance to enter value. Random value will be set.{Environment.NewLine}");
					break;
				}

				if (!isParsed)
				{
					Console.WriteLine($"The value you entered is not number. Please, try again.{Environment.NewLine}");

				}
				else if (validatedUsersValue < 0)
				{
					Console.WriteLine($"The value you entered is negative. Please, try again.{Environment.NewLine}");
				}

				else if (validatedUsersValue == 0)
				{
					Console.WriteLine($"The value you entered is zero. Please, try again.{Environment.NewLine}");
				}
			}

			return Math.Round(GetRandomNumberAfter3FailedAttempts());
		}

		public void PossibilityFiguresToBeInside(double circleArea, double squareArea)
		{
			//possible if the diameter of the Circle <=  than the side of the Square
			if (2 * Math.Sqrt(circleArea / Math.PI) <= Math.Sqrt(squareArea))
			{
				Console.WriteLine($"The Circle will fit in the Square.");
			}

			//possible if the diameter of the Circle >=  than the diagonal of the Square
			else if (2 * Math.Sqrt(circleArea / Math.PI) >= Math.Sqrt(2) * Math.Sqrt(squareArea))
			{
				Console.WriteLine($"The Square will fit in the Circle.");
			}

			else
			{
				Console.WriteLine($"It is impossible to put figures into each other.");
			}
		}
	}
}