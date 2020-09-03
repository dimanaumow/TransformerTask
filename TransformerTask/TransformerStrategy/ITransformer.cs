namespace TransformerStrategy
{
    /// <summary>
    /// Provide the transformation.
    /// </summary>
    public interface ITransformer
    {
        /// <summary>
        /// Abstracts the transformation rule.
        /// </summary>
        /// <param name="item">Double item.</param>
        /// <returns>Transform string.</returns>
        string Transform(double item);
    }
}
