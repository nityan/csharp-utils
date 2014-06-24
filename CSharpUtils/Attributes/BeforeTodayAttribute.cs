/**
 * Created by Nityan Khanna on June 23 2014
 */

using System;
using System.ComponentModel.DataAnnotations;

namespace CSharpUtils.Attributes
{
	/// <summary>
	/// Specifies that the data field value is before today.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public sealed class BeforeTodayAttribute : ValidationAttribute
	{
		/// <summary>
		/// Initializes a new instance of the BeforeTodayAttribute class.
		/// </summary>
		public BeforeTodayAttribute()
		{
		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value.GetType() != typeof(DateTime))
			{
				throw new InvalidOperationException("Cannot validate non-DateTime property");
			}

			if (string.IsNullOrEmpty(ErrorMessage))
			{
				ErrorMessage = "Invalid DateTime";
			}

			DateTime dateTimeProperty = (DateTime)value;

			return dateTimeProperty < DateTime.Now ? ValidationResult.Success : new ValidationResult(ErrorMessage);
		}
	}
}