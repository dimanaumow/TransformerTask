using System;

namespace TransformerInheritance
{
    /// <summary>
    /// Describes the abstraction of transformer class.
    /// </summary>
    public abstract class Transformer
    {
        /// <summary>
        /// Transform elements according to a certain rule.
        /// </summary>
        /// <param name="source">Source array.</param>
        /// <returns>Array of "ieee-754 format".</returns>
        /// <exception cref="ArgumentNullException">Throws, when source array is null.</exception>
        /// <exception cref="ArgumentException">Throws, when source array is empty.</exception>
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

            var result = new string[source.Length];

            for (int i = 0; i < source.Length; i++)
            {
                result[i] = this.TransformAccordingToRule(source[i]);
            }

            return result;
        }

        /// <summary>
        /// Defines the transformation rules.
        /// </summary>
        /// <param name="item">The number, that is being transformed.</param>
        /// <returns>The resulting transform string.</returns>
        protected abstract string TransformAccordingToRule(double item);
    }
}
