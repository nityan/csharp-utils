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
using System.Collections.Generic;
using System.Linq;

namespace CSharpUtils.Extensions
{
	/// <summary>
	/// Represents a collection of extension methods for the <see cref="List{T}"/> class.
	/// </summary>
	public static class ListExtensions
	{
		/// <summary>
		/// Replaces an element in a list.
		/// </summary>
		/// <typeparam name="T">The type of the list.</typeparam>
		/// <param name="source">The list to perform the replace operation on.</param>
		/// <param name="match">The predicate match.</param>
		/// <param name="value">The new value to be inserted into the list.</param>
		/// <returns>Returns the list with the update value.</returns>
		public static IEnumerable<T> Replace<T>(this IEnumerable<T> source, Predicate<T> match, T value)
		{
			var enumerable = source as T[] ?? source.ToArray();

			ThrowIfNullSource<T>(enumerable);

			var clonedList = enumerable.ToList();

			var index = enumerable.ToList().FindIndex(match);

			if (index == -1)
			{
				throw new Exception($"Item not found using predicate {match}");
			}

			clonedList[index] = value;

			return clonedList.AsEnumerable();
		}

		/// <summary>
		/// Throws an exception if the source is null.
		/// </summary>
		/// <param name="source">The source.</param>
		private static void ThrowIfNullSource<T>(IEnumerable<T> source)
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source), "Value cannot be null");
			}
		}
	}
}
