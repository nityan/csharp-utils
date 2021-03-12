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
using System.ComponentModel.DataAnnotations;

namespace CSharpUtils.Attributes
{
	/// <summary>
	/// Represents an attribute that provides a utility attribute that compares if two properties should not equal.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	public sealed class CompareNotEqualAttribute : ValidationAttribute
	{
		/// <summary>
		/// The other property name.
		/// </summary>
		private readonly string otherPropertyName;

		/// <summary>
		/// Initializes a new instance of the <see cref="CompareNotEqualAttribute"/> class.
		/// </summary>
		/// <param name="otherProperty">The other property.</param>
		/// <exception cref="System.ArgumentNullException">Cannot compare to null</exception>
		public CompareNotEqualAttribute(string otherProperty)
		{
			if (string.IsNullOrEmpty(otherProperty))
			{
				throw new ArgumentNullException(nameof(otherProperty), "Value cannot be null");
			}

			this.otherPropertyName = otherProperty;
		}

		/// <summary>
		/// Validates the specified value with respect to the current validation attribute.
		/// </summary>
		/// <param name="value">The value to validate.</param>
		/// <param name="validationContext">The context information about the validation operation.</param>
		/// <returns>An instance of the <see cref="System.ComponentModel.DataAnnotations.ValidationResult"></see> class.</returns>
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var otherPropertyValue = validationContext?.ObjectType.GetProperty(this.otherPropertyName)?.GetValue(validationContext.ObjectInstance, null);

			if (string.IsNullOrEmpty(this.ErrorMessage))
			{
				this.ErrorMessage = $"The {validationContext?.DisplayName} is invalid";
			}

			return otherPropertyValue != value ? ValidationResult.Success : new ValidationResult(this.ErrorMessage);
		}
	}
}