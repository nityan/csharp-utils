/**
 * Created by Nityan Khanna on Mar 29 2014
 */

using CSharpUtils.Encryption;
using CSharpUtils.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography;

namespace CSharpUtilsTest
{
	[TestClass]
	public class EncryptionManagerTest
	{
		[TestMethod]
		public void DecryptData_ShouldPass()
		{
			string password = "password";

			byte[] encryptedData = EncryptionManager.EncryptData(password, "string".GetBytes());

			byte[] decryptedData = EncryptionManager.DecryptData(password, encryptedData);

			Assert.AreEqual("string", decryptedData.GetString());
		}

		[TestMethod]
		public void EncryptData_ShouldPass()
		{
			string password = "password";

			byte[] data = EncryptionManager.EncryptData(password, "string".GetBytes());

			Assert.AreNotEqual("string", data);
		}


	}
}
