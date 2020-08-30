using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace TransformerToWordPartial
{
    /// <summary>
    /// Implement transformer class.
    /// </summary>
    public partial class Transformer
    {
        /// <summary>
        /// Gets dictionary, that maps each valid digit or character their valid word values.
        /// </summary>
        /// <value>Dictionary chars and strings.</value>
        public static Dictionary<char, string> Keys => new Dictionary<char, string>
        {
                { '0', "zero" },
                { '1', "one" },
                { '2', "two" },
                { '3', "three" },
                { '4', "four" },
                { '5', "five" },
                { '6', "six" },
                { '7', "seven" },
                { '8', "eight" },
                { '9', "nine" },
                { '-', "minus" },
                { '.', "point" },
                { 'E', "E" },
                { '+', "plus" },
        };

        /// <summary>
        /// Gets dictionary, that maps each non-valid double numbers their text description.
        /// </summary>
        /// <value>Dictionary doubles and strings.</value>
        public static Dictionary<double, string> SpecialKeys => new Dictionary<double, string>
        {
            { double.NaN, "Not a Number" },
            { double.PositiveInfinity, "Positive Infinity" },
            { double.NegativeInfinity, "Negative Infinity" },
            { double.Epsilon, "Double Epsilon" },
        };

        static partial void TransformByPredicate(ICollection<string> collection, double item)
        {
            bool flag = SpecialKeys.TryGetValue(item, out string result);
            if (flag)
            {
                collection.Add(result);
            }
            else
            {
                string value = item.ToString(CultureInfo.InvariantCulture);

                var builder = new StringBuilder();
                for (int i = 0; i < value.Length; i++)
                {
                    if (i == value.Length - 1)
                    {
                        builder.Append($"{Keys[value[i]]}");
                        break;
                    }

                    builder.Append($"{Keys[value[i]]} ");
                }

                result = builder.ToString();
                collection.Add($"{result.Substring(0, 1).ToUpper(CultureInfo.InvariantCulture)}" +
                    $"{(result.Length > 1 ? result.Substring(1) : string.Empty)}");
            }
        }
    }
}
