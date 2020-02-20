using System;

namespace Task1_2ForCourses
{
	public class Circle
	{
		public Circle(double userInputRadius)
		{
			CircleRadius = userInputRadius;
			CircleArea = CalculateCircleArea();
		}

		public double CircleRadius { get; private set; }

		public double CircleArea { get; private set; }

		private double CalculateCircleArea()
		{
			return (Math.PI * Math.Pow(CircleRadius, 2));
		}

		public void PrintRadiusCircleArea()
		{
			Console.WriteLine(
				$"The radius value you entered is: {CircleRadius}, calculated Circle Area is: {Math.Round(CircleArea, 2)}{Environment.NewLine}");
		}
	}
}