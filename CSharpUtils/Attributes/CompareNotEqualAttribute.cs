/**
 * Created by Nityan Khanna on Mar 12 2014
 */

using System;
using System.ComponentModel.DataAnnotations;

namespace CSharpUtils.Attributes
{

	/// <summary>
	/// Provides a utility attribute that compares if two properties should not equal.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public sealed class CompareNotEqualAttribute : ValidationAttribute
	{

		/// <summary>
		/// The name of the property to compare to.
		/// </summary>
		public string OtherProperty { get; set; }

		public CompareNotEqualAttribute(string otherProperty)
		{
			if (otherProperty == null)
			{
				throw new ArgumentNullException("Cannot compare to null");
			}
			else
			{
				OtherProperty = otherProperty;
			}
		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var otherPropertyValue = validationContext.ObjectType.GetProperty(OtherProperty).GetValue(validationContext.ObjectInstance, null);

			if (string.IsNullOrEmpty(ErrorMessage))
			{
				ErrorMessage = "The " + validationContext.DisplayName + " is invalid.";
			}

			return !otherPropertyValue.Equals(value) ? ValidationResult.Success : new ValidationResult(ErrorMessage);
		}
	}
}