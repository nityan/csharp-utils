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
    public sealed class StringValueAttribute : Attribute
    {
        public StringValueAttribute(string text)
        {
            Text = text;
        }

        /// <summary>
        /// The text which belongs to this member.
        /// </summary>
		public string Text { get; private set; }
    }
}