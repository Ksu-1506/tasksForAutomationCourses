using NUnit.Framework;
using NUnit_Calculator.Calculators;
using Assert = NUnit.Framework.Assert;


namespace NUnit_Calculator.Tests
{
	[TestFixture]
	public class CalculatorTest
	{
		private double _firstNum;
		private double _secondNum;
		private double _actualResult;
		private double _expectedResult;
		public readonly ICalculator Calc = new SimpleCalculator();


		[SetUp]
		public void SetUp()
		{
			_firstNum = 1;
			_secondNum = 1;
		} 

		[TearDown]
		public void TearDown()
		{
			_firstNum = 0;
			_secondNum = 0;
		}

		[Test]
		public void AdditionTwoNumbers()
		{
			_expectedResult = 2;
			_actualResult = Calc.Adding(_firstNum, _secondNum);
			Assert.AreEqual(_expectedResult, _actualResult, $"Actual result of addition {_firstNum} and {_secondNum} must be equal to {_expectedResult}");
		}

		[Test]
		public void AdditionIntAndDouble()
		{
			_firstNum = 5;
			_secondNum = 6.8;
			_expectedResult = 11.8;
			_actualResult = Calc.Adding(_firstNum, _secondNum);
			Assert.AreEqual(_expectedResult, _actualResult, $"Actual result of addition {_firstNum} and {_secondNum} must be equal to {_expectedResult}");
		}

		[Test, Order(3)]
		public void SubtractingTwoNumbers()
		{
			_firstNum = 32;
			_secondNum = 12;
			_expectedResult = 20;
			_actualResult = Calc.Subtraction(_firstNum, _secondNum);
			Assert.AreEqual(_expectedResult, _actualResult, $"Actual result of subtracting {_firstNum} and {_secondNum} must be equal to {_expectedResult}");
		}

		[Test, Retry(5)]
		public void MultiplicationTwoNumbers()
		{
			_firstNum = 4;
			_secondNum = 11;
			_expectedResult = 44;
			_actualResult = Calc.Multiplication(_firstNum, _secondNum);
			Assert.AreEqual(_expectedResult, _actualResult, $"Actual result of multiplication {_firstNum} and {_secondNum} must be equal to {_expectedResult}");
		}

		[Test, Order(2)]
		public void DivisionTwoNumbers()
		{
			_firstNum = 30;
			_secondNum = 6;
			_expectedResult = 5;
			Assert.AreNotEqual(0, _secondNum, "Second number is not 0");
			_actualResult = Calc.Division(_firstNum, _secondNum);
			Assert.AreEqual(_expectedResult, _actualResult, $"Actual result of division {_firstNum} and {_secondNum} must be equal to {_expectedResult}");
		}

		[Test, Order(1)]
		public void DivisionAreNotSame()
		{
			_firstNum = 25;
			_secondNum = 5;
			_expectedResult = 12;
			_actualResult = Calc.Division(_firstNum, _secondNum);
			object expectedResult = _expectedResult;
			object actualResult = _actualResult;
			Assert.AreNotSame(actualResult, expectedResult, $"Expected and actual results of division {_firstNum} and {_secondNum} are not same ");
		}

		[Test]
		public void DivisionResultIsNotEmpty()
		{
			_firstNum = 25;
			_secondNum = 5;
			var result = Calc.Division(_firstNum, _secondNum).ToString();
			Assert.IsNotEmpty(result, $"Result of division {_firstNum} and {_secondNum} is not empty");
		}

		[Test, MaxTime(100), Retry(6)]
		public void FailDivisionResultIsEmpty()
		{
			_firstNum = 25;
			_secondNum = 2;
			var result = Calc.Division(_firstNum, _secondNum).ToString();
			Assert.IsEmpty(result, $"Result of division {_firstNum} and {_secondNum} is not empty");
		}

		[Test]
		[Ignore("Please, ignore this test")]
		public void IgnoredTest()
		{
			_firstNum = 2;
			_secondNum = 12;
			_expectedResult = 24;
			_actualResult = Calc.Multiplication(_firstNum, _secondNum);
			Assert.AreEqual(_expectedResult, _actualResult, $"Actual result of multiplication {_firstNum} and {_secondNum} must be equal to {_expectedResult}");
		}

		[Test]
		[Ignore("Waiting for Joe to fix his bugs", Until = "2020-03-01 12:00:00Z")]
		public void IgnoredTestUntilTime()
		{
			_firstNum = 5;
			_secondNum = 10;
			_expectedResult = 50;
			_actualResult = Calc.Multiplication(_firstNum, _secondNum);
			Assert.AreEqual(_expectedResult, _actualResult, $"Actual result of multiplication {_firstNum} and {_secondNum} must be equal to {_expectedResult}");
		}

		[Test]
		public void AlwaysPass()
		{
			_firstNum = 33;
			_secondNum = 41.5;
			_actualResult = Calc.Multiplication(_firstNum, _secondNum);
			Assert.AreEqual(_actualResult, _actualResult, $"Actual result of multiplication {_firstNum} and {_secondNum} must be equal to {_actualResult}");
		}


		[Test]
		public void AlwaysFail()
		{
			_firstNum = 33;
			_secondNum = 41.5;
			_actualResult = Calc.Adding(_firstNum, _secondNum);
			Assert.AreEqual(_actualResult, null, $"Actual result of multiplication {_firstNum} and {_secondNum} must be equal to {_actualResult}");
		}
	}
}
