/*
 * Copyright 2015-2019 Nityan Khanna
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

namespace CSharpUtils.Attributes
{
	/// <summary>
	/// Represents an attribute containing a string representation of the member.
	/// </summary>
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class StringValueAttribute : Attribute
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="StringValueAttribute"/> class.
		/// </summary>
		/// <param name="text">The text.</param>
		public StringValueAttribute(string text)
		{
			this.Text = text;
		}

		/// <summary>
		/// The text which belongs to this member.
		/// </summary>
		public string Text { get; }
	}
}