using System;
using System.Collections.Generic;

namespace TransformerToWordPartial
{
    /// <summary>
    /// Implement transformer class.
    /// </summary>
    public partial class Transformer
    {
        /// <summary>
        /// Transform each element of source array into its "word format".
        /// </summary>
        /// <param name="source">Source array.</param>
        /// <returns>Array of "word format" of elements of source array.</returns>
        /// <exception cref="ArgumentNullException">Throw if array is null.</exception>
        /// <exception cref="ArgumentException">Throw if array is empty.</exception>
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