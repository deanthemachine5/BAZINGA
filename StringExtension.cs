using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace Loves.Common
{
    /// <summary>
    /// String Extension Methods
    /// </summary>
    public static class StringExtension
    {
        #region Substring Methods

        /// <summary>
        /// Lefts the specified text.
        /// </summary>
        /// <param name="text">The text to be trimmed.</param>
        /// <param name="length">The length of the string from the left.</param>
        /// <returns>string data type</returns>
        [DebuggerStepThrough]
        public static string Left(this string text, int length)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return text;
            }

            text = text.Trim();
            return text.Substring(0, Math.Min(text.Length, length));
        }

        /// <summary>
        /// Rights the specified text.
        /// </summary>
        /// <param name="text">The text to be trimmed.</param>
        /// <param name="length">The length from the right.</param>
        /// <returns>string data type</returns>
        [DebuggerStepThrough]
        public static string Right(this string text, int length)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return text;
            }

            text = text.Trim();
            return text.Substring(Math.Max(text.Length - length, 0));
        }

        #endregion Substring Methods

        #region TypeCast Methods

        /// <summary>
        /// Converts this instance to an instance of&lt;System.Boolean&gt;.
        /// </summary>
        /// <param name="text">The <see cref="String"/> text.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        [DebuggerStepThrough]
        public static bool? ToBool(this string text)
        {
            bool value;
            if (!bool.TryParse(text, out value))
            {
                return null;
            }

            return value;
        }

        /// <summary>
        /// Converts this instance to an instance of&lt;System.DateTime&gt;.
        /// </summary>
        /// <param name="text">The <see cref="String"/> text.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        [DebuggerStepThrough]
        public static DateTime? ToDateTime(this string text)
        {
            DateTime value;
            if (!DateTime.TryParse(text, out value))
            {
                return null;
            }

            return value;
        }

        /// <summary>
        /// Converts this instance to an instance of&lt;System.Decimal&gt;.
        /// </summary>
        /// <param name="text">The <see cref="String"/> text.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        [DebuggerStepThrough]
        public static decimal? ToDecimal(this string text)
        {
            decimal value;
            if (!decimal.TryParse(text.RemoveNonnumericOther(), NumberStyles.Number, CultureInfo.CurrentCulture, out value))
            {
                return null;
            }

            return value;
        }

        /// <summary>
        /// Converts this instance to an instance of&lt;System.Double&gt;.
        /// </summary>
        /// <param name="text">The <see cref="String"/> text.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        [DebuggerStepThrough]
        public static double? ToDouble(this string text)
        {
            double value;
            if (!double.TryParse(text.RemoveNonnumericOther(), NumberStyles.Number, CultureInfo.CurrentCulture, out value))
            {
                return null;
            }

            return value;
        }

        /// <summary>
        /// Converts this instance to a GUID.
        /// </summary>
        /// <param name="text">The <see cref="String"/> text.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        [DebuggerStepThrough]
        public static Guid? ToGuid(this string text)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(text))
                {
                    return new Guid(text);
                }
            }
            catch (System.FormatException)
            {
            }
            catch (System.ArgumentException)
            {
            }
            catch (System.OverflowException)
            {
            }

            return null;
        }

        /// <summary>
        /// Converts this instance to an instance of 16 bit integer.
        /// </summary>
        /// <param name="text">The <see cref="String"/> text.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        [DebuggerStepThrough]
        public static short? ToInt16(this string text)
        {
            short value;
            if (!short.TryParse(text, NumberStyles.Integer | NumberStyles.AllowThousands, CultureInfo.CurrentCulture, out value))
            {
                return null;
            }

            return value;
        }

        /// <summary>
        /// Converts this instance to an instance of integer.
        /// </summary>
        /// <param name="text">The <see cref="String"/> text.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        [DebuggerStepThrough]
        public static int? ToInt32(this string text)
        {
            int value;
            if (!int.TryParse(text, NumberStyles.Integer | NumberStyles.AllowThousands, CultureInfo.CurrentCulture, out value))
            {
                return null;
            }

            return value;
        }

        /// <summary>
        /// Converts this instance to an instance of 64 bit integer.
        /// </summary>
        /// <param name="text">The <see cref="String"/> text.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        [DebuggerStepThrough]
        public static long? ToInt64(this string text)
        {
            long value;
            if (!long.TryParse(text, NumberStyles.Integer | NumberStyles.AllowThousands, CultureInfo.CurrentCulture, out value))
            {
                return null;
            }

            return value;
        }

        /// <summary>
        /// Converts this instance to an instance of IPAddress.
        /// </summary>
        /// <param name="text">The <see cref="String"/> text.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        [DebuggerStepThrough]
        public static IPAddress ToIPAddress(this string text)
        {
            IPAddress ipaddress;
            if (!IPAddress.TryParse(text, out ipaddress))
            {
                return null;
            }

            return ipaddress;
        }

        /// <summary>
        /// Converts this instance to an instance of&lt;System.Decimal&gt;.
        /// </summary>
        /// <param name="text">The <see cref="String"/> text.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        [DebuggerStepThrough]
        public static decimal? ToMoney(this string text)
        {
            decimal value;
            if (!decimal.TryParse(text, NumberStyles.Currency, CultureInfo.CurrentCulture, out value))
            {
                return null;
            }

            return value;
        }

        /// <summary>
        /// Converts this instance to an instance of&lt;System.Decimal&gt;.
        /// </summary>
        /// <param name="text">The <see cref="String"/> text.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static decimal? ToPercent(this string text)
        {
            decimal value;
            if (!decimal.TryParse(text.RemoveNonnumericOther(), NumberStyles.Number, CultureInfo.CurrentCulture, out value))
            {
                return null;
            }

            return value / 100;
        }

        #endregion TypeCast Methods

        #region String Array TypeCast Methods

        /// <summary>
        /// Converts an array of strings to an array of integers.  Any value that will not convert is dropped from results.
        /// </summary>
        /// <param name="text">The strings to convert to integers.</param>
        /// <returns>Array of integers.</returns>
        [DebuggerStepThrough]
        public static int[] ToInt32(this string[] text)
        {
            return text.Select(s => s.ToInt32())
                       .Where(s => s.HasValue)
                       .Select(s => s.Value)
                       .ToArray();
        }

        #endregion String Array TypeCast Methods

        #region Format Methods

        /// <summary>
        /// Formats the federal tax id number. This is the Format for Employers
        /// </summary>
        /// <param name="text">The text be converted.</param>
        /// <returns>string data type</returns>
        [DebuggerStepThrough]
        public static string FormatFederalTaxIdNumber(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return text;
            }

            if (9 == text.Length)
            {
                return string.Format("{0}-{1}", text.Substring(0, 2), text.Substring(2, 7));
            }

            return text;
        }

        /// <summary>
        /// Formats the phone number.
        /// </summary>
        /// <param name="text">The text be converted.</param>
        /// <returns>string data type</returns>
        [DebuggerStepThrough]
        public static string FormatPhoneNumber(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return text;
            }

            if (10 == text.Length)
            {
                return string.Format("({0}) {1}-{2}", text.Substring(0, 3), text.Substring(3, 3), text.Substring(6, 4));
            }

            if (7 == text.Length)
            {
                return string.Format("{0}-{1}", text.Substring(0, 3), text.Substring(3, 4));
            }

            return text;
        }

        /// <summary>
        /// Formats the postal code.
        /// </summary>
        /// <param name="text">The text be converted.</param>
        /// <returns>string data type</returns>
        [DebuggerStepThrough]
        public static string FormatPostalCode(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return text;
            }

            if (9 == text.Length)
            {
                return string.Format("{0}-{1}", text.Substring(0, 5), text.Substring(5, 4));
            }

            return text;
        }

        /// <summary>
        /// Formats the social security number.
        /// </summary>
        /// <param name="text">The text to be converted.</param>
        /// <returns>string data type</returns>
        [DebuggerStepThrough]
        public static string FormatSocialSecurityNumber(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return text;
            }

            if (9 == text.Length)
            {
                return string.Format("{0}-{1}-{2}", text.Substring(0, 3), text.Substring(3, 2), text.Substring(5, 4));
            }

            return text;
        }

        /// <summary>
        /// Invalids the filename characters.
        /// </summary>
        /// <returns>Invalid file name characters</returns>
        public static string GetInvalidFileNameCharacters()
        {
            return string.Format("[{0}]", Regex.Escape(Path.GetInvalidFileNameChars().Join(",")));
        }

        /// <summary>
        /// Nulls if empty.
        /// </summary>
        /// <param name="text">The text to check for null.</param>
        /// <returns>null if string is empty</returns>
        [DebuggerStepThrough]
        public static string NullIfEmpty(this string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text", "The text parameter must not be null.");
            }

            if (string.IsNullOrWhiteSpace(text))
            {
                return null;
            }

            return text;
        }

        /// <summary>
        /// Removes the invalid filename characters.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>String with invalid file name characters removed.</returns>
        public static string RemoveInvalidFileNameCharacters(this string value)
        {
            return Regex.Replace(value, GetInvalidFileNameCharacters(), string.Empty);
        }

        /// <summary>
        /// Removes the non alphanumeric characters.
        /// </summary>
        /// <param name="text">The provided string of text to be converted.</param>
        /// <returns>A string data type.</returns>
        [DebuggerStepThrough]
        public static string RemoveNonAlphanumeric(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return text;
            }

            return Regex.Replace(text, "[^a-zA-Z0-9]", string.Empty);
        }

        /// <summary>
        /// Removes the nonnumeric characters.
        /// </summary>
        /// <param name="text">The text be converted.</param>
        /// <returns>string data type</returns>
        [DebuggerStepThrough]
        public static string RemoveNonnumeric(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return text;
            }

            return Regex.Replace(text, "[^0-9]", string.Empty);
        }

        /// <summary>
        /// Removes the non numeric other.
        /// </summary>
        /// <param name="text">The text be converted.</param>
        /// <returns>string data type</returns>
        [DebuggerStepThrough]
        public static string RemoveNonnumericOther(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return text;
            }

            return Regex.Replace(text, "[^0-9\\.\\-\\,\\$]", string.Empty);
        }

        /// <summary>
        /// Splits the camel case.
        /// </summary>
        /// <param name="text">The value.</param>
        /// <param name="separator">The separator.</param>
        /// <returns>Split on camel case</returns>
        [DebuggerStepThrough]
        public static string SplitCamelCase(this string text, string separator)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return text;
            }

            Regex r = new Regex("(?<=[a-z])(?<x>[A-Z])|(?<=.)(?<x>[A-Z])(?=[a-z])");
            return r.Replace(text, separator + "${x}").Replace("  ", " ");
        }

        /// <summary>
        /// Converts this instance to an instance of String.
        /// </summary>
        /// <param name="text">The <see cref="String"/> text.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        [DebuggerStepThrough]
        public static string ToTitleCase(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return text;
            }

            return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
        }

        #endregion Format Methods

        #region Comparison Methods

        /// <summary>
        /// Determines whether the current instance contains the specified value, ignoring case.
        /// </summary>
        /// <param name="text">The text to compare.</param>
        /// <param name="value">The value to compare.</param>
        /// <returns>
        /// <c>true</c> if the current instance contains the specified value; otherwise, <c>false</c>.
        /// </returns>
        public static bool ContainsIgnoreCase(this string text, string value)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text", "The value parameter must not be null.");
            }

            return text.IndexOf(value, 0, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        #endregion Comparison Methods
    }
}