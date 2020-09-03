using System;

namespace TransformerStrategy
{
    /// <summary>
    /// Implement transform class.
    /// </summary>
    public class Transformer
    {
        /// <summary>
        /// Transform elements according to a certain rule.
        /// </summary>
        /// <param name="source">Source array.</param>
        /// <param name="transformer">Transformation rule.</param>
        /// <returns>Array of "ieee-754 format".</returns>
        /// <exception cref="ArgumentNullException">Throws, when source array is null.</exception>
        /// <exception cref="ArgumentException">Throws, when source array is empty.</exception>
        public string[] Transform(double[] source, ITransformer transformer)
        {
            if (source is null)
            {
                throw new ArgumentNullException($"{nameof(source)} cannot be null.");
            }

            if (source.Length == 0)
            {
                throw new ArgumentException($"{nameof(source)} cannot be empty.");
            }

            if (transformer is null)
            {
                throw new ArgumentNullException($"{nameof(transformer)} cannot be null."); 
            }

            var result = new string[source.Length];

            for (int i = 0; i < source.Length; i++)
            {
                result[i] = transformer.Transform(source[i]);
            }

            return result;
        }
    }
}
