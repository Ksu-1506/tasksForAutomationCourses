namespace NUnit_Calculator.Calculators
{
	public interface IScientificCalculator
	{
		double Power(double num1, double num2);
		double PercentageNum1FromNum2(double num1, double num2);
		double Modulo(double num1, double num2);
		double ArraySum(double[] array);
		double ArrayMaxValue(double[] array);
		double ArrayMinValue(double[] array);
	}
}
