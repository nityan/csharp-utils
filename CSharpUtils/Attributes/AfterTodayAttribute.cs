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
	/// Represents an attribute that specifies that the data field value is after today.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	public sealed class AfterTodayAttribute : ValidationAttribute
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AfterTodayAttribute"/> class.
		/// </summary>
		public AfterTodayAttribute(string errorMessage)
		{
			if (string.IsNullOrEmpty(errorMessage))
			{
				throw new ArgumentNullException(nameof(errorMessage), "Value cannot be null");
			}

			this.ErrorMessage = errorMessage;
		}

		/// <summary>
		/// Validates the specified value with respect to the current validation attribute.
		/// </summary>
		/// <param name="value">The value to validate.</param>
		/// <param name="validationContext">The context information about the validation operation.</param>
		/// <returns>An instance of the <see cref="System.ComponentModel.DataAnnotations.ValidationResult"></see> class.</returns>
		/// <exception cref="System.InvalidOperationException">Cannot validate non-DateTime property</exception>
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (!(value is DateTime))
			{
				throw new InvalidOperationException("Cannot validate non-DateTime property");
			}

			return (DateTime)value > DateTime.Now ? ValidationResult.Success : new ValidationResult(ErrorMessage);
		}
	}
}