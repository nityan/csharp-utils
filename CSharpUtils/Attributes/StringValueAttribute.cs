/**
 * Created by Nityan Khanna on Mar 14 2014
 */

using System;

namespace CSharpUtils.Attributes
{

    /// <summary>
    /// Defines an attribute containing a string representation of the member
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class StringValueAttribute : Attribute
    {
        public StringValueAttribute(string text)
        {
            Text = text;
        }

		public StringValueAttribute(string text, object value)
		{
			Text = text;
			Value = value;
		}

        /// <summary>
        /// The text which belongs to this member.
        /// </summary>
		public string Text { get; private set; }

		/// <summary>
		/// A corresponding value to associate with the string value of the field.
		/// </summary>

		public object Value { get; private set; }
    }
}