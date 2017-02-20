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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpUtils.Extensions
{
	/// <summary>
	/// Represents a collection of extension methods for the <see cref="System.String"/> class.
	/// </summary>
	public static class StringExtensions
	{
		/// <summary>
		/// Determines whether the string has a trailing back slash.
		/// </summary>
		/// <param name="source">The source string.</param>
		/// <returns>Return true if the string has a trailing back slash.</returns>
		public static bool HasTrailingBackSlash(this string source)
		{
			ThrowIfNullSource(source);

			return source.EndsWith("\\");
		}

		/// <summary>
		/// Determines whether the string has a trailing forward slash.
		/// </summary>
		/// <param name="source">The source string.</param>
		/// <returns>Return true if the string has a trailing forward slash.</returns>
		public static bool HasTrailingForwardSlash(this string source)
		{
			ThrowIfNullSource(source);

			return source.EndsWith("/");
		}

		/// <summary>
		/// Removes a trailing back slash from a string.
		/// </summary>
		/// <param name="source">The source string.</param>
		/// <returns>Returns the string without the trailing back slash.</returns>
		public static string RemoveTrailingBackSlash(this string source)
		{
			return source.Substring(0, source.LastIndexOf('\\'));
		}

		/// <summary>
		/// Removes a trailing forward slash from a string.
		/// </summary>
		/// <param name="source">The source string.</param>
		/// <returns>Returns the string without the trailing forward slash.</returns>
		public static string RemoveTrailingForwardSlash(this string source)
		{
			return source.Substring(0, source.LastIndexOf('/'));
		}

		/// <summary>
		/// Throws an exception if the source string is null.
		/// </summary>
		/// <param name="source">The source string.</param>
		private static void ThrowIfNullSource(string source)
		{
			if (source == null)
			{
				throw new ArgumentNullException(string.Format("{0} cannot be null", nameof(source)));
			}
		}
	}
}
