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
using CSharpUtils.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpUtils.Tests
{
	public enum TestEnum
	{
		[StringValue("test1")]
		Test1,

		[StringValue("test2")]
		Test2
	}

	[TestClass]
	public class StringValueAttributeTest
	{
		[TestMethod]
		public void StringValueAttributeTest_ShouldFail()
		{
			string expected = "asdf";

			string actual = TestEnum.Test2.GetStringValue();

			Assert.AreNotEqual(expected, actual);
		}

		[TestMethod]
		public void StringValueAttributeTest_ShouldPass()
		{
			string expected = "test1";

			string actual = TestEnum.Test1.GetStringValue();

			Assert.AreEqual(expected, actual);
		}
	}
}