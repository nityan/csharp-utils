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
using System.IO;

namespace CSharpUtils.Extensions
{
	/// <summary>
	/// Contains extensions for the <see cref="Stream"/> class.
	/// </summary>
	public static class StreamExtensions
	{
		/// <summary>
		/// Reads a given stream to the end as a string.
		/// </summary>
		/// <param name="source">The source.</param>
		/// <returns>Returns a string representing the result of the stream.</returns>
		public static string ReadToEndAsString(this Stream source)
		{
			ThrowIfNullSource(source);

			string result;

			using (var streamReader = new StreamReader(source))
			{
				result = streamReader.ReadToEnd();
			}

			return result;
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
