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

using CSharpUtils.Attributes;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace CSharpUtils.Extensions
{
	/// <summary>
	/// A collection of reflection extension methods.
	/// </summary>
	public static class ReflectionExtensions
	{
		/// <summary>
		/// Gets all the public properties of an object.
		/// </summary>
		/// <param name="obj">The data type for which the method is defined.</param>
		/// <returns>Returns an array containing the property info of the object.</returns>
		public static IEnumerable<PropertyInfo> GetProperties(this object obj)
		{
			return obj.GetType().GetProperties();
		}

		/// <summary>
		/// Gets the properties of an object.
		/// </summary>
		/// <param name="obj">The data type for which the method is defined.</param>
		/// <param name="flags">Flags to provide to determine which properties to retrieve.</param>
		/// <returns>Returns an array containing the property info of the object.</returns>
		public static IEnumerable<PropertyInfo> GetProperties(this object obj, BindingFlags flags)
		{
			return obj.GetType().GetProperties(flags);
		}

		/// <summary>
		/// Get the property value on the current object for a property with the specified name.
		/// </summary>
		/// <param name="obj">The object for which the property value is to be retrieved.</param>
		/// <param name="propertyName">The name of the property whose value is to be retrieved.</param>
		/// <returns>Returns the value of the property.</returns>
		public static object GetPropertyValue(this object obj, string propertyName)
		{
			object value = null;
			PropertyInfo item = obj.GetType().GetProperty(propertyName);

			if (item != null)
			{
				value = obj.GetType().GetProperty(propertyName).GetValue(obj);

				if (item.PropertyType.IsGenericType)
				{
					value = item.PropertyType.GetProperty(propertyName);
				}
			}

			return value;
		}

		/// <summary>
		/// Gets a string value for an enum.
		/// </summary>
		/// <param name="obj">The enum for which to return the string value for.</param>
		/// <returns>Returns a string value for an enum.</returns>
		public static string GetStringValue(this Enum obj)
		{
			FieldInfo fieldInfo = obj.GetType().GetField(obj.ToString());
			StringValueAttribute[] attributes = fieldInfo.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];

			StringValueAttribute output = (StringValueAttribute)attributes.GetValue(0);

			return output.Text;
		}
	}
}