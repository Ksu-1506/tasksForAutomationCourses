using System;

namespace Task1_2ForCourses
{
	public class Square
	{
		public Square(double userInputSide)
		{
			SquareSide = userInputSide;
			SquareArea = CalculateSquareArea();
		}

		public double SquareSide { get; set; }

		public double SquareArea { get; set; }

		private double CalculateSquareArea()
		{
			return Math.Pow(SquareSide, 2);
		}


		public void PrintSideSquareArea()
		{
			Console.WriteLine(
				$"The side value you entered is: {SquareSide}, calculated Square Area is: {Math.Round(SquareArea, 2)}{Environment.NewLine}");
		}
	}
}