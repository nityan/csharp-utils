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
using CSharpUtils.Attributes;
using System;
using System.Reflection;

namespace CSharpUtils.Extensions
{
	/// <summary>
	/// Contains a collection of string value attribute enum extension methods.
	/// </summary>
	public static class StringValueAttributeEnumExtensions
	{
		/// <summary>
		/// Gets a string value for an enum.
		/// </summary>
		/// <param name="source">The enum for which to return the string value for.</param>
		/// <returns>Returns a string value for an enum.</returns>
		public static string GetStringValue(this Enum source)
		{
			ThrowIfNullSource(source);

			return source.GetType().GetField(source.ToString())?.GetCustomAttribute<StringValueAttribute>()?.Text;
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