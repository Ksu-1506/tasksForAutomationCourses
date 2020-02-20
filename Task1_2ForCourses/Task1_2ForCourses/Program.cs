using System;

namespace Task1_2ForCourses
{
	class Program
	{
		static void Main(string[] args)
		{
			MathCalc calculation = new MathCalc();

			Circle circle = new Circle(calculation.CheckNotNegativeValueInGetters("radius", "Circle"));
			circle.PrintRadiusCircleArea();

			Square square = new Square(calculation.CheckNotNegativeValueInGetters("side", "Square"));
			square.PrintSideSquareArea();

			calculation.PossibilityFiguresToBeInside(circle.CircleArea, square.SquareArea);

			Console.ReadKey();
		}
	}
}