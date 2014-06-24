using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CSharpUtils.Attributes
{

	/// <summary>
	/// Specifies that the data field value is after today.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public sealed class AfterTodayAttribute : ValidationAttribute
	{
		/// <summary>
		/// Initializes a new instance of the AfterTodayAttribute class.
		/// </summary>
		public AfterTodayAttribute()
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

			return dateTimeProperty > DateTime.Now ? ValidationResult.Success : new ValidationResult(ErrorMessage);
		}
	}
}