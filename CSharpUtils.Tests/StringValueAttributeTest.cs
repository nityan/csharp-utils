using CSharpUtils.Attributes;
using CSharpUtils.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpUtils.Tests
{
    [TestClass]
    public class StringValueAttributeTest
    {
        [TestMethod]
        public void StringValueAttributeTest_ShouldPass()
        {
            string expected = "test1";

            string actual = TestEnum.Test1.GetStringValue();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StringValueAttributeTest_ShouldFail()
        {
            string expected = "asdf";

			string actual = TestEnum.Test2.GetStringValue();

            Assert.AreNotEqual(expected, actual);
        }
    }

    public enum TestEnum
    {
        [StringValue("test1")]
        Test1,
        [StringValue("test2")]
        Test2
    }
}
