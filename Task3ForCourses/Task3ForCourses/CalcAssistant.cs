using System;

namespace Task3ForCourses
{
	class CalcAssistant
	{
		private int _startValueForUserRange;
		private int _endValueForUserRange;

		public void GetUserRangeValues()
		{
			Console.WriteLine("Please enter positive integer or zero for start point of your range:");

			while (!(Int32.TryParse(Console.ReadLine(), out _startValueForUserRange)) || _startValueForUserRange < 0)
			{
				Console.WriteLine(
					$"Entered value {_startValueForUserRange} is invalid. Please enter a non-negative integer for start point of your range:");
				Console.Clear();
			}

			Console.WriteLine($"{Environment.NewLine}Please enter positive integer for end point of your range: ");

			while (!(Int32.TryParse(Console.ReadLine(), out _endValueForUserRange)) || 
			       (_endValueForUserRange < _startValueForUserRange + 10))
			{
				Console.WriteLine(
					"Entered value is invalid - array length less than 10. Please enter positive integer for end point of your range:");
			}
		}

		private int[] GenerateUserArray()
		{
			int[] userArray = new int[(_endValueForUserRange - _startValueForUserRange + 1)];

			for (int i = 0; i < userArray.Length; i++)
			{
				userArray[i] = _startValueForUserRange + i;
			}

			return userArray;
		}

		private int GetSum()
		{
			int sum = 0;
			foreach (int i in GenerateUserArray())
			{
				if (i % 3 == 0 && i % 5 != 0)
				{
					sum += i;
				}
			}

			return sum;
		}

		public void PrintArrayElementsSum()
		{
			Console.WriteLine(
				$"Your attention!!! Sum of elements in your array (that starts with {_startValueForUserRange} and ends {_endValueForUserRange}) that are divisible by 3, but not divisible by 5: {GetSum()}");
		}
	}
}