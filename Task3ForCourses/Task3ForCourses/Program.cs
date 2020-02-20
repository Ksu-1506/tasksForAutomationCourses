using System;

namespace Task3ForCourses
{
	class Program
	{
		static void Main(string[] args)
		{
			CalcAssistant calcAssistant = new CalcAssistant();
			calcAssistant.GetUserRangeValues();
			calcAssistant.PrintArrayElementsSum();
			Console.ReadKey();
		}
	}
}
