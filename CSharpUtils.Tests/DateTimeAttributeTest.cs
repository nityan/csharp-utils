/*
 * Copyright 2015-2019 Nityan Khanna
 * 
 * Licensed under the Apache License, Version 2.0 (the "License"); you 
 * may not use this file except in compliance with the License. You may 
 * obtain a copy of the License at 
 * 
 * http://www.apache.org/licenses/LICENSE-2.0 
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the 
 * License for the specific language governing permissions and limitations under 
 * the License.
 * 
 * User: Nityan Khanna
 * Date: 2019-3-17
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