/**
 * Created by Nityan Khanna on Mar 14 2014
 */

using CSharpUtils.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharpUtils.Extensions
{
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
