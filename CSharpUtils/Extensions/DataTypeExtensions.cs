/**
 * Created by Nityan Khanna on Mar 14 2014
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CSharpUtils.Extensions
{

	public static class DataTypeExtensions
	{

		/// <summary>
		/// Generates a salt of a given length.
		/// </summary>
		/// <param name="random">The data type for which the method is defined.</param>
		/// <param name="size">The size of the salt byte array.</param>
		/// <returns>A byte array containing the salt.</returns>
		public static byte[] GenerateSalt(this Random random, int size)
		{
			byte[] salt = new byte[size];

			using (RNGCryptoServiceProvider CryptoProvider = new RNGCryptoServiceProvider())
			{
				CryptoProvider.GetNonZeroBytes(salt);
			}

			return salt;
		}

		/// <summary>
		/// Gets the bytes of a string.
		/// </summary>
		/// <param name="str">The string to retrieve the bytes from.</param>
		/// <returns>Returns a byte array from a string.</returns>
		public static byte[] GetBytes(this string str)
		{
			byte[] bytes = new byte[str.Length * sizeof(char)];
			Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
			return bytes;
		}

		/// <summary>
		/// Gets a string from a byte array.
		/// </summary>
		/// <param name="bytes">The byte array to create to a string.</param>
		/// <returns>Returns a string from a byte array.</returns>
		public static string GetString(this byte[] bytes)
		{
			char[] chars = new char[bytes.Length / sizeof(char)];
			Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
			return new string(chars);
		}

		/// <summary>
		/// Computes the hash of a byte array.
		/// </summary>
		/// <param name="data">Byte array to hash.</param>
		/// <param name="algorithm">Hash algorithm to use (defaults to SHA256).</param>
		/// <returns>The hash of the byte array.</returns>
		public static byte[] Hash(this byte[] data, HashAlgorithm algorithm = null)
		{
			byte[] hashedByteArray = null;

			if (algorithm == null)
			{
				using (SHA256CryptoServiceProvider sha256Hash = new SHA256CryptoServiceProvider())
				{
					hashedByteArray = sha256Hash.ComputeHash(data);
				}
			}
			else
			{
				hashedByteArray = algorithm.ComputeHash(data);
			}

			return hashedByteArray;
		}

		/// <summary>
		/// Computes the hash of a string.
		/// </summary>
		/// <param name="data">The string to hash.</param>
		/// <param name="algorithm">Algorithm to use. Defaults to SHA1.</param>
		/// <param name="encoding">Encoding used by the string. Defaults to UTF-8.</param>
		/// <returns>The hash of the string.</returns>
		public static string Hash(this string data, HashAlgorithm algorithm = null, Encoding encoding = null)
		{
			if (algorithm == null)
			{
				algorithm = new SHA1CryptoServiceProvider();
			}

			if (encoding == null)
			{
				encoding = Encoding.UTF8;
			}

			return BitConverter.ToString(data.ToByteArray(encoding).Hash(algorithm));
		}

		/// <summary>
		/// Converts a byte array to a Base64 string with options.
		/// </summary>
		/// <param name="bytes">The bytes to convert to the Base64 string.</param>
		/// <returns>Returns a Base64 encoded string.</returns>
		public static string ToBase64(this byte[] bytes)
		{
			return Convert.ToBase64String(bytes);
		}

		/// <summary>
		/// Converts a byte array to a Base64 string with options.
		/// </summary>
		/// <param name="bytes">The bytes to convert to the Base64 string.</param>
		/// <param name="options">The Base64 formatting options.</param>
		/// <returns>Returns a Base64 encoded string.</returns>
		public static string ToBase64(this byte[] bytes, Base64FormattingOptions options)
		{
			return Convert.ToBase64String(bytes, options);
		}


		/// <summary>
		/// Transforms a string to a byte array.
		/// </summary>
		/// <param name="str">The data type for which the method is defined.</param>
		/// <param name="encoding">The encoding used to retrieve the byte array. Defaults to UTF-8.</param>
		/// <returns>The byte array of the string.</returns>
		public static byte[] ToByteArray(this string str, Encoding encoding = null)
		{
			byte[] value = null;

			if (encoding == null)
			{
				value = Encoding.UTF8.GetBytes(str);
			}
			else
			{
				value = encoding.GetBytes(str);
			}

			return value;
		}
	}
}
