using System;

namespace TransformerInheritance
{
    public abstract class Transformer
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

            var result = new string[source.Length]; 

            for (int i = 0; i < source.Length; i++)
            {
                result[i] = TransformAccordingToRule(source[i]);
            }

            return result;
        }

        protected abstract string TransformAccordingToRule(double item);
    }
}
