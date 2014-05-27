using CSharpUtils.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharpUtilsTest
{
	[TestClass]
	public class ReflectionExtensionsTest
	{
		[TestMethod]
		public void GetPropertyValueTest_ShouldPass()
		{
			Person person1 = new Person
			{
				Id = "123456",
				Name = "Bob Dole"
			};

			Person person2 = new Person
			{
				Id = "12345",
				Name = "Bob Dole"
			};

			string expected = person1.GetPropertyValue("Name") as string;
			string actual = person2.GetPropertyValue("Name") as string;

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void GetPropertyValueTest_ShouldFail()
		{
			Person person1 = new Person
			{
				Id = "54321",
				Name = "Bob Dole"
			};

			Person person2 = new Person
			{
				Id = "12345",
				Name = "Bob Dole"
			};

			string expected = person1.GetPropertyValue("Id") as string;
			string actual = person2.GetPropertyValue("Id") as string;

			Assert.AreNotEqual(expected, actual);
		}
	}

	public class Person
	{
		public Person()
		{
		}

		public string Id { get; set; }

		public string Name { get; set; }
	}
}
