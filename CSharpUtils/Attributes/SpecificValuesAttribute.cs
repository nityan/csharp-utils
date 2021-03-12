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
using System.Linq;

namespace CSharpUtils.Attributes
{
	/// <summary>
	/// Represents a attribute to check if the current value is a valid value in a value set.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public sealed class SpecificValueAttribute : ValidationAttribute
	{
		/// <summary>
		/// The values to compare.
		/// </summary>
		private readonly object[] values;

		/// <summary>
		/// Initialzes a new instance of the SpecificValueAttribute class.
		/// </summary>
		/// <param name="values">The value(s) to validate against.</param>
		public SpecificValueAttribute(params object[] values)
		{
			this.values = values ?? throw new ArgumentNullException(nameof(values), "Value cannot be null");
		}

		/// <summary>
		/// Determines whether the specified value of the object is valid.
		/// </summary>
		/// <param name="value">The value of the object to validate.</param>
		/// <returns>true if the specified value is valid; otherwise, false.</returns>
		public override bool IsValid(object value)
		{
			return value != null && this.values.Contains(value);
		}
	}
}