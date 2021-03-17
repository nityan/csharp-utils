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
using System.ComponentModel.DataAnnotations;

namespace CSharpUtils.Tests
{
	/// <summary>
	/// Represents an after today test class.
	/// </summary>
	public class AfterTodayTest
	{
		/// <summary>
		/// Gets or sets the must be after today.
		/// </summary>
		/// <value>The must be after today.</value>
		[AfterToday("The date time value must be after today")]
		public DateTime MustBeAfterToday { get; set; }
	}

	/// <summary>
	/// Represents a before today test class.
	/// </summary>
	public class BeforeTodayTest
	{
		/// <summary>
		/// Gets or sets the must be before today.
		/// </summary>
		/// <value>The must be before today.</value>
		[BeforeToday("The date time value must be before today")]
		public DateTime MustBeBeforeToday { get; set; }
	}

	/// <summary>
	/// Defines tests for the <see cref="AfterTodayAttribute"/> class and the <see cref="BeforeTodayAttribute"/> class.
	/// </summary>
	[TestClass]
	public class DateTimeAttributeTest
	{
		private AfterTodayTest afterTodayTest;
		private BeforeTodayTest beforeTodayTest;
		private ValidationContext validationContext;

		/// <summary>
		/// Runs cleanup after each test.
		/// </summary>
		[TestCleanup]
		public void Cleanup()
		{
			this.afterTodayTest = null;
			this.beforeTodayTest = null;
		}

		/// <summary>
		/// Runs initialization before each test.
		/// </summary>
		[TestInitialize]
		public void Initialize()
		{
			this.afterTodayTest = new AfterTodayTest();
			this.beforeTodayTest = new BeforeTodayTest();
		}

		/// <summary>
		/// Defines the test method AfterTodayAttributeTest_ShouldFail.
		/// </summary>
		[TestMethod]
		public void AfterTodayAttributeTest_ShouldFail()
		{
			this.afterTodayTest.MustBeAfterToday = new DateTime(DateTime.Now.Year - 1, 10, 5);

			this.validationContext = new ValidationContext(this.afterTodayTest)
			{
				MemberName = nameof(AfterTodayTest.MustBeAfterToday)
			};

			Assert.IsFalse(Validator.TryValidateProperty(this.afterTodayTest.MustBeAfterToday, this.validationContext, null));
		}

		/// <summary>
		/// Defines the test method AfterTodayAttributeTest_ShouldPass.
		/// </summary>
		[TestMethod]
		public void AfterTodayAttributeTest_ShouldPass()
		{
			this.afterTodayTest.MustBeAfterToday = new DateTime(DateTime.Now.Year + 1, 10, 5);

			this.validationContext = new ValidationContext(this.afterTodayTest)
			{
				MemberName = nameof(AfterTodayTest.MustBeAfterToday)
			};

			Assert.IsTrue(Validator.TryValidateProperty(this.afterTodayTest.MustBeAfterToday, this.validationContext, null));
		}

		/// <summary>
		/// Defines the test method BeforeTodayAttributeTest_ShouldFail.
		/// </summary>
		[TestMethod]
		public void BeforeTodayAttributeTest_ShouldFail()
		{
			this.beforeTodayTest.MustBeBeforeToday = new DateTime(DateTime.Now.Year + 1, 10, 5);

			this.validationContext = new ValidationContext(this.beforeTodayTest)
			{
				MemberName = nameof(BeforeTodayTest.MustBeBeforeToday)
			};

			Assert.IsFalse(Validator.TryValidateProperty(this.beforeTodayTest.MustBeBeforeToday, this.validationContext, null));
		}

		/// <summary>
		/// Defines the test method BeforeTodayAttributeTest_ShouldPass.
		/// </summary>
		[TestMethod]
		public void BeforeTodayAttributeTest_ShouldPass()
		{
			this.beforeTodayTest.MustBeBeforeToday = new DateTime(DateTime.Now.Year - 1, 10, 5);

			this.validationContext = new ValidationContext(this.beforeTodayTest)
			{
				MemberName = nameof(BeforeTodayTest.MustBeBeforeToday)
			};

			Assert.IsTrue(Validator.TryValidateProperty(this.beforeTodayTest.MustBeBeforeToday, this.validationContext, null));
		}
	}
}