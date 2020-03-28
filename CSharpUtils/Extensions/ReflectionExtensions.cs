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
 * Date: 2020-3-27
 */
using System;

namespace CSharpUtils.Extensions
{
	/// <summary>
	/// Represents a class with extension methods for easily using common reflection processes.
	/// </summary>
	public static class ReflectionExtensions
	{
		/// <summary>
		/// Gets the property value.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source">The source.</param>
		/// <param name="propertyName">Name of the property.</param>
		/// <returns>T.</returns>
		/// <exception cref="ArgumentNullException">propertyName - Value cannot be null</exception>
		/// <exception cref="ArgumentException">Unable to find property: {propertyName} on object: {source}</exception>
		/// <exception cref="InvalidCastException">Unable to cast: {propertyInfo.PropertyType} to {typeof(T)}</exception>
		public static T GetPropertyValue<T>(this object source, string propertyName) where T : class
		{
			ThrowIfNullSource(source);

			if (string.IsNullOrEmpty(propertyName))
			{
				throw new ArgumentNullException(nameof(propertyName), "Value cannot be null");
			}

			var propertyInfo = source.GetType().GetProperty(propertyName);

			if (propertyInfo == null)
			{
				throw new ArgumentException($"Unable to find property: {propertyName} on object: {source}");
			}

			var returnValue = propertyInfo.GetValue(source) as T;

			if (returnValue == null)
			{
				throw new InvalidCastException($"Unable to cast: {propertyInfo.PropertyType} to {typeof(T)}");
			}

			return returnValue;
		}

		/// <summary>
		/// Throws if null source.
		/// </summary>
		/// <param name="source">The source.</param>
		/// <exception cref="ArgumentNullException">source - Value cannot be null</exception>
		private static void ThrowIfNullSource(object source)
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source), "Value cannot be null");
			}
		}
	}
}
