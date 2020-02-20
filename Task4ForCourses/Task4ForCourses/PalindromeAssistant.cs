using System;

namespace Task4ForCourses
{
	class PalindromeAssistant
	{
		private string _computerString;

		public void PrintAnswer()
		{
			if (!ValidationIsPalindrome())
			{
				Console.WriteLine("Very regret, but text you entered is not a palindrome.");
			}

			else
			{
				Console.WriteLine("Congratulations!!! Text you entered is a palindrome.");
			}
		}

		private void GetUserString()
		{
			Console.WriteLine("Please enter the text you want to check:");
			var userString = Console.ReadLine().ToLower();

			while (String.IsNullOrWhiteSpace(userString))
			{
				Console.Clear();

				Console.WriteLine("Sorry, but your entered value is null or empty. Please enter the text again:");
				userString = Console.ReadLine().ToLower();
			}

			for (int i = 0; i < userString.Length; i++)
			{
				if (char.IsLetter(userString, i) || char.IsDigit(userString[i]))
				{
					_computerString += userString[i];
				}
			}

		}

		private bool ValidationIsPalindrome()
		{
			GetUserString();

			for (int i = 0; i < _computerString.Length / 2; i++)
			{
				if (_computerString[i] != _computerString[_computerString.Length - i - 1])
				{
					return false;
				}
			}

			return true;
		}
	}
}