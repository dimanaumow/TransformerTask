using System;
using System.Collections;
using System.Collections.Generic;

namespace TransformerToIEEEPartial
{
    public partial class Transformer
    {
        public string[] Transform(double[] source)
        {
            if (source is null)
            {
                throw new ArgumentNullException($"{nameof(source)} cannot be null.");
            }

            if (source.Length == 0)
            {
                throw new ArgumentException($"{nameof(source)} cannot be empty.");
            }

            var result = new List<string>(source.Length);

            for (int i = 0; i < source.Length; i++)
            {
                TransformByPredicate(result, source[i]);
            }

            return result.ToArray();
        }

        static partial void TransformByPredicate(ICollection<string> collection, double item);
    }
}
