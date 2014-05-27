/**
 * Created by Nityan Khanna on Mar 12 2014
 */

using CSharpUtils.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CSharpUtils.Encryption
{

	public static class EncryptionManager
	{
		private static ICryptoTransform CreatePassword(string key, EncryptMode mode)
		{
			SHA256 sha256 = new SHA256Managed();
			byte[] keyHash = sha256.ComputeHash(key.GetBytes(), 0, 16);

			AesManaged aesManaged = new AesManaged();
			aesManaged.GenerateIV();

			return mode == EncryptMode.Encrypt ? aesManaged.CreateEncryptor(keyHash, aesManaged.IV) : aesManaged.CreateDecryptor(keyHash, aesManaged.IV);
		}

		public static byte[] DecryptData(string key, byte[] encryptedData)
		{
			AesCryptoServiceProvider aesCryptoServiceProvider = new AesCryptoServiceProvider();

			ICryptoTransform password = CreatePassword(key, EncryptMode.Decrypt);

			byte[] decryptedData = null;

			using (MemoryStream memoryStream = new MemoryStream())
			{
				CryptoStream cryptoStream = new CryptoStream(memoryStream, password, CryptoStreamMode.Write);
				cryptoStream.Write(encryptedData, 0, encryptedData.Length);
				decryptedData = memoryStream.ToArray();
			}

			return decryptedData;
		}

		public static byte[] EncryptData(string key, byte[] data)
		{
			AesCryptoServiceProvider aesCryptoServiceProvider = new AesCryptoServiceProvider();

			ICryptoTransform password = CreatePassword(key, EncryptMode.Encrypt);

			byte[] encryptedData = null;

			using (MemoryStream memoryStream = new MemoryStream())
			{
				CryptoStream cryptoStream = new CryptoStream(memoryStream, password, CryptoStreamMode.Write);
				cryptoStream.Write(data, 0, data.Length);
				encryptedData = memoryStream.ToArray();
			}

			return encryptedData;
		}

		private enum EncryptMode
		{
			Encrypt,
			Decrypt
		}
	}
}
