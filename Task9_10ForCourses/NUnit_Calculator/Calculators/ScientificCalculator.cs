using System;
using System.Linq;

namespace NUnit_Calculator.Calculators
{
	public class ScientificCalculator : IScientificCalculator
	{
		public double Power(double num1, double num2)
		{
			return Math.Pow(num1, num2);
		}

		public double PercentageNum1FromNum2(double num1, double num2)
		{
			return (num1 * 100) / num2;
		}

		public double Modulo(double num1, double num2)
		{
			return num1 % num2;
		}

		public double ArraySum(double[] array)
		{
			return array.Sum();
		}

		public double ArrayMaxValue(double[] array)
		{
			return array.Max();
		}

		public double ArrayMinValue(double[] array)
		{
			return array.Min();
		}
	}
}
