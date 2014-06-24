/**
 * Created by Nityan Khanna on May 21 2014
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpUtils.Attributes
{
	/// <summary>
	/// Represents a attribute to check if the current value is a valid value in a value set.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public sealed class SpecificValueAttribute : ValidationAttribute
	{
		/// <summary>
		/// Initialzes a new instance of the SpecificValueAttribute class.
		/// </summary>
		/// <param name="values">The value(s) to validate against.</param>
		public SpecificValueAttribute(params object[] values)
		{
			if (values == null)
			{
				throw new ArgumentNullException("The values parameter cannot be null");
			}

			Values = values;
		}

		/// <summary>
		/// The value(s) which are valid values for the property.
		/// </summary>
		public object[] Values { get; private set; }

		public override bool IsValid(object value)
		{
			return Values.Contains(value);
		}
	}
}
