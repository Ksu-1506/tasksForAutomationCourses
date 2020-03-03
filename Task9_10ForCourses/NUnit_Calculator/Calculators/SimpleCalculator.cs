namespace NUnit_Calculator.Calculators
{
	public class SimpleCalculator : ICalculator
	{
		public double Adding(double num1, double num2)
		{
			return num1 + num2;
		}

		public double Subtraction(double num1, double num2)
		{
			return num1 - num2;
		}

		public double Multiplication(double num1, double num2)
		{
			return num1 * num2;
		}
		
		public double Division(double num1, double num2)
		{
			return num1 / num2;
		}
	}
}
