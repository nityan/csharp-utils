/**
 * Created by Nityan Khanna on June 23 2014
 */

using CSharpUtils.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSharpUtils.Tests
{
	[TestClass]
	public class DateTimeAttributeTest
	{
		[TestMethod]
		public void AfterTodayAttributeTest_ShouldPass()
		{
			AfterTodayTest afterToday = new AfterTodayTest();

			afterToday.MustBeAfterToday = new DateTime(2022, 10, 5);

			ValidationContext validationContext = new ValidationContext(afterToday)
			{
				MemberName = "MustBeAfterToday"
			};

			var results = new List<ValidationResult>();

			Assert.IsTrue(Validator.TryValidateProperty(afterToday.MustBeAfterToday, validationContext, results));
		}

		[TestMethod]
		public void AfterTodayAttributeTest_ShouldFail()
		{
			AfterTodayTest afterToday = new AfterTodayTest();

			afterToday.MustBeAfterToday = new DateTime(1993, 10, 5);

			ValidationContext validationContext = new ValidationContext(afterToday)
			{
				MemberName = "MustBeAfterToday"
			};

			Assert.IsFalse(Validator.TryValidateProperty(afterToday.MustBeAfterToday, validationContext, null));
		}

		[TestMethod]
		public void BeforeTodayAttributeTest_ShouldPass()
		{
			BeforeTodayTest beforeToday = new BeforeTodayTest();

			beforeToday.MustBeBeforeToday = new DateTime(1993, 10, 5);

			ValidationContext validationContext = new ValidationContext(beforeToday)
			{
				MemberName = "MustBeBeforeToday"
			};

			Assert.IsTrue(Validator.TryValidateProperty(beforeToday.MustBeBeforeToday, validationContext, null));
		}

		[TestMethod]
		public void BeforeTodayAttributeTest_ShouldFail()
		{
			BeforeTodayTest beforeToday = new BeforeTodayTest();

			beforeToday.MustBeBeforeToday = new DateTime(2165, 10, 5);

			ValidationContext validationContext = new ValidationContext(beforeToday)
			{
				MemberName = "MustBeBeforeToday"
			};

			Assert.IsFalse(Validator.TryValidateProperty(beforeToday.MustBeBeforeToday, validationContext, null));
		}
	}

	public class AfterTodayTest
	{
		[AfterToday]
		public DateTime MustBeAfterToday { get; set; }
	}

	public class BeforeTodayTest
	{
		[BeforeToday]
		public DateTime MustBeBeforeToday { get; set; }
	}
}
