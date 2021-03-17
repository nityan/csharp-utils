/*
 * Copyright 2015-2020 Nityan Khanna
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

using System;
using System.Security.Cryptography;
using System.Text;

namespace CSharpUtils.Extensions
{
	/// <summary>
	/// A collection of datatype extension methods.
	/// </summary>
	public static class DataTypeExtensions
	{
		/// <summary>
		/// Generates a salt of a given length.
		/// </summary>
		/// <param name="source">The data type for which the method is defined.</param>
		/// <param name="size">The size of the salt byte array.</param>
		/// <returns>A byte array containing the salt.</returns>
		public static byte[] GenerateSalt(this Random source, int size)
		{
			ThrowIfNullSource(source);

			var salt = new byte[size];

			using (var cryptoProvider = new RNGCryptoServiceProvider())
			{
				cryptoProvider.GetNonZeroBytes(salt);
			}

			return salt;
		}

		/// <summary>
		/// Gets the bytes of a string.
		/// </summary>
		/// <param name="source">The string to retrieve the bytes from.</param>
		/// <returns>Returns a byte array from a string.</returns>
		public static byte[] GetBytes(this string source)
		{
			ThrowIfNullSource(source);

			var bytes = new byte[source.Length * sizeof(char)];
			Buffer.BlockCopy(source.ToCharArray(), 0, bytes, 0, bytes.Length);
			return bytes;
		}

		/// <summary>
		/// Gets a string from a byte array.
		/// </summary>
		/// <param name="source">The byte array to create to a string.</param>
		/// <returns>Returns a string from a byte array.</returns>
		public static string GetString(this byte[] source)
		{
			ThrowIfNullSource(source);

			var chars = new char[source.Length / sizeof(char)];

			Buffer.BlockCopy(source, 0, chars, 0, source.Length);

			return new string(chars);
		}

		/// <summary>
		/// Computes the hash of a byte array.
		/// </summary>
		/// <param name="source">The byte array to hash.</param>
		/// <param name="algorithm">Hash algorithm to use (defaults to SHA256).</param>
		/// <returns>Returns the hash of the byte array.</returns>
		public static byte[] Hash(this byte[] source, HashAlgorithm algorithm = null)
		{
			ThrowIfNullSource(source);

			algorithm ??= new SHA256CryptoServiceProvider();

			return algorithm.ComputeHash(source);
		}

		/// <summary>
		/// Computes the hash of a string.
		/// </summary>
		/// <param name="source">The string to hash.</param>
		/// <param name="algorithm">Algorithm to use. Defaults to SHA1.</param>
		/// <param name="encoding">Encoding used by the string. Defaults to UTF-8.</param>
		/// <returns>The hash of the string.</returns>
		public static string Hash(this string source, HashAlgorithm algorithm = null, Encoding encoding = null)
		{
			ThrowIfNullSource(source);

			algorithm ??= new SHA256CryptoServiceProvider();
			encoding ??= Encoding.UTF8;

			return BitConverter.ToString(source.ToByteArray(encoding).Hash(algorithm));
		}

		/// <summary>
		/// Converts a byte array to a Base64 string with options.
		/// </summary>
		/// <param name="source">The bytes to convert to the Base64 string.</param>
		/// <returns>Returns a Base64 encoded string.</returns>
		public static string ToBase64(this byte[] source)
		{
			ThrowIfNullSource(source);
			return Convert.ToBase64String(source);
		}

		/// <summary>
		/// Converts a byte array to a Base64 string with options.
		/// </summary>
		/// <param name="source">The bytes to convert to the Base64 string.</param>
		/// <param name="options">The Base64 formatting options.</param>
		/// <returns>Returns a Base64 encoded string.</returns>
		public static string ToBase64(this byte[] source, Base64FormattingOptions options)
		{
			ThrowIfNullSource(source);
			return Convert.ToBase64String(source, options);
		}

		/// <summary>
		/// Transforms a string to a byte array.
		/// </summary>
		/// <param name="source">The data type for which the method is defined.</param>
		/// <param name="encoding">The encoding used to retrieve the byte array. Defaults to UTF-8.</param>
		/// <returns>The byte array of the string.</returns>
		public static byte[] ToByteArray(this string source, Encoding encoding = null)
		{
			ThrowIfNullSource(source);

			encoding ??= Encoding.UTF8;

			return encoding.GetBytes(source);
		}

		/// <summary>
		/// Throws an exception if the source is null.
		/// </summary>
		/// <param name="source">The source.</param>
		private static void ThrowIfNullSource(object source)
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source), "Value cannot be null");
			}
		}
	}
}