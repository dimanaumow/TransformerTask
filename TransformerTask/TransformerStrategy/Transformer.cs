using System;

namespace TransformerStrategy
{   
    public class Transformer
    {
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
