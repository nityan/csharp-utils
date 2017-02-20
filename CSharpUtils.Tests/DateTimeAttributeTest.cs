/*
 * Copyright (c) 2017 Nityan Khanna
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 * 
 * User: Nityan
 * Date: 2017-2-20
 */
using CSharpUtils.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSharpUtils.Tests
{
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

	[TestClass]
	public class DateTimeAttributeTest
	{
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
	}
}