/**
 * Created by Nityan Khanna on Mar 14 2014
 */

using CSharpUtils.Attributes;
using CSharpUtils.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace CSharpUtilsTest
{
	[TestClass]
	public class StringValueTest
	{
		[TestMethod]
		public void StringValueAttributeEnumTest_ShouldPass()
		{
			string actual1 = TestEnum.TestVal.GetStringValue();
			string actual2 = TestEnum.TestVal2.GetStringValue();

			Assert.AreEqual<string>("test1", actual1);
			Assert.AreEqual<string>("test2", actual2);

		}

		[TestMethod]
		public void StringValueAttributeEnumTest_ShouldFail()
		{
			string actual = TestEnum.TestVal.GetStringValue();

			Assert.AreNotEqual<string>("test12", actual);
		}
	}

	public enum TestEnum
	{

		[StringValue("test1")]
		TestVal,
		[StringValue("test2")]
		TestVal2,
		[StringValue("test3")]
		TestVal3
	}
}
