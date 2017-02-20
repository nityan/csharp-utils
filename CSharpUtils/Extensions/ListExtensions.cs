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
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
			var clonedList = source.ToList();

			var index = source.ToList().FindIndex(match);

			if (index == -1)
			{
				throw new Exception($"Item not found using predicate {match}");
			}

			clonedList[index] = value;

			return clonedList.AsEnumerable();
		}
	}
}
