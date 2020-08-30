using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TransformerInheritance.DerivedTransformers
{
    public class TransformToWords : Transformer
    {
        public Dictionary<char, string> Keys => new Dictionary<char, string>
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

        public Dictionary<double, string> SpecialKeys => new Dictionary<double, string>
        {
            { double.NaN, "Not a Number" },
            { double.PositiveInfinity, "Positive Infinity" },
            { double.NegativeInfinity, "Negative Infinity" },
            { double.Epsilon, "Double Epsilon" },
        };

        protected override string TransformAccordingToRule(double item)
        {
            bool flag = this.SpecialKeys.TryGetValue(item, out string result);
            if (flag)
            {
                return result;
            }

            string value = item.ToString(CultureInfo.InvariantCulture);

            var builder = new StringBuilder();
            for (int i = 0; i < value.Length; i++)
            {
                if (i == value.Length - 1)
                {
                    builder.Append($"{this.Keys[value[i]]}");
                    break;
                }

                builder.Append($"{this.Keys[value[i]]} ");
            }

            result = builder.ToString();
            return $"{result.Substring(0, 1).ToUpper(CultureInfo.InvariantCulture)}" +
                $"{(result.Length > 1 ? result.Substring(1) : string.Empty)}";
        }
    }
}
