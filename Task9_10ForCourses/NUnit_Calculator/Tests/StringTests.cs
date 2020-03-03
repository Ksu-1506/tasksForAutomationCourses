using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NUnit_Calculator.Tests
{
	[TestFixture]
	public class StringTests
	{
		private string _firstString;
		private string _secondString;

		[Test]
		public void StringContainsTest()
		{
			_firstString = "He was born in Herat on 9 February 1441";
			_secondString = "9 February 1441";
			StringAssert.Contains(_secondString, _firstString,
				$"String '{_firstString}' is contains '{_secondString}'");

		}

		[Test]
		public void StringStartsWithValue()
		{
			_firstString = "Ukrainian nation is very talented";
			_secondString = "Ukrainian";
			StringAssert.StartsWith(_secondString, _firstString, $"String '{_firstString}' is starts with '{_secondString}'");

		}

		[Test]
		public void StringsAreEqualIgnoringCase()
		{
			_firstString = "Go home only after all work is done";
			_secondString = "go HoMe onlY aFter all work is done";
			StringAssert.AreEqualIgnoringCase(_secondString, _firstString, $"String '{_secondString}' is equals to '{_firstString}' ignoring case");
		}
	}
}
