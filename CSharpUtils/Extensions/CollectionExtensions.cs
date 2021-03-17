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
 * Date: 2020-11-18
 */
using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharpUtils.Extensions
{
	/// <summary>
	/// Contains extension methods for the <see cref="ICollection"/> and <see cref="ICollection{T}"/> interfaces.
	/// </summary>
	public static class CollectionExtensions
	{
		/// <summary>
		/// Adds a range of items to a collection.
		/// </summary>
		/// <typeparam name="T">The type of value.</typeparam>
		/// <param name="source">The source.</param>
		/// <param name="values">The values.</param>
		public static void AddRange<T>(this ICollection<T> source, T[] values)
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source), "Value cannot be null");
			}

			if (values == null)
			{
				throw new ArgumentNullException(nameof(values), "Value cannot be null");
			}

			foreach (var value in values)
			{
				source.Add(value);
			}
		}
	}
}
