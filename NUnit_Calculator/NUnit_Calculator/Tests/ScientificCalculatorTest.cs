using System;
using NUnit.Framework;
using NUnit_Calculator.Calculators;
using Assert = NUnit.Framework.Assert;


namespace NUnit_Calculator.Tests
{
	[TestFixture]
	public class ScientificCalculatorTest
	{
		private double _firstNum;
		private double _secondNum;
		private double _actualResult;
		private double _expectedResult; 
		public readonly IScientificCalculator ScientificCalc = new ScientificCalculator();

		[SetUp]
		public void SetUp()
		{
			_firstNum = 7;
			_secondNum = 4;
		}

		[TearDown]
		public void TearDown()
		{
			_firstNum = 0;
			_secondNum = 0;
		}

		[Test, Description("Power test for two numbers")]
		public void PowerTwoNumbers()
		{
			_expectedResult = 2401;
			_actualResult = ScientificCalc.Power(_firstNum, _secondNum); 
			Assert.AreEqual(_expectedResult, _actualResult, $"Actual result of {_firstNum} in {_secondNum} power must be equal to {_expectedResult}");
		}

		[Test, Description("Fail power test for two numbers")]
		public void FailPowerTwoNumbers()
		{
			_expectedResult = 2;
			_actualResult = ScientificCalc.Power(_firstNum, _secondNum);
			Assert.AreEqual(_expectedResult, _actualResult, $"Actual result of {_firstNum} in {_secondNum} power must be equal to {_expectedResult}");
		}

		[Test, Description("The percentage of the first number from the second")]
		public void PercentageFirstNumberFromSecond()
		{
			_firstNum = 50;
			_secondNum = 300;
			_expectedResult = 16.666666666666668;
			_actualResult = ScientificCalc.PercentageNum1FromNum2(_firstNum, _secondNum);
			Assert.AreEqual(_expectedResult, _actualResult, $"Actual result for percentage of the {_firstNum} from the {_secondNum} must be equal to {_expectedResult}");
		}

		[Test, Description("The remainder of dividing the first number by the second")]
		public void ModuloTwoNumbers()
		{
			_expectedResult = 3;
			_actualResult = ScientificCalc.Modulo(_firstNum, _secondNum);
			Assert.AreEqual(_expectedResult, _actualResult, $"Actual result remainder of dividing the {_firstNum} by the {_secondNum} must be equal to {_expectedResult}");
		}

		[Test]
		public void ArraySum()
		{
			double[] array = { 1, 2, 3, 4, 5, 6 };
			_expectedResult = 21;
			_actualResult = ScientificCalc.ArraySum(array);
			Assert.AreEqual(_expectedResult, _actualResult, $"Actual result sum of array ({array})  must be equal to {_expectedResult}");
		}

		[Test, Retry(4)]
		public void ArrayMaxValue()
		{
			double[] array = { 134, 27, 15, 456, 77, 32, -3, 44 };
			_expectedResult = 456;
			_actualResult = ScientificCalc.ArrayMaxValue(array);
			Assert.AreEqual(_expectedResult, _actualResult, $"Actual result of calculating the maximum array ({array})  value must be equal to {_expectedResult}");
		}

		[Test]
		public void ArrayMinValue()
		{
			double[] array = { -4, -27, 315, 56, -77, 32};
			_expectedResult = -77;
			_actualResult = ScientificCalc.ArrayMinValue(array);
			Assert.AreEqual(_expectedResult, _actualResult, $"Actual result of calculating the minimum array ({array})  must be equal to {_expectedResult}");
		}

		[Test]
		public void FailArrayMinValue()
		{
			double[] array = { 2, 2, 2, 2, 2 };
			_expectedResult = 1;
			_actualResult = ScientificCalc.ArrayMinValue(array);
			Assert.AreEqual(_expectedResult, _actualResult, $"Actual result of calculating the minimum array ({array})  must be equal to {_expectedResult}");
		}
	}
}
