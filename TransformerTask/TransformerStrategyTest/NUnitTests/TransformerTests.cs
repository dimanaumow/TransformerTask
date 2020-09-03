using NUnit.Framework;
using System;
using TransformerStrategy;
using TransformerStrategy.TransformerImplementation;

namespace TransformerStrategyTest.NUnitTests
{
    public class TransformerTests
    {
        [Test]
        public void Transform_ArrayIsNull_ThrowArgumentNullException()
        {
            var transformationRule = new TransformerToWords();
            Assert.Throws<ArgumentNullException>(() => new Transformer().Transform(null, transformationRule), "Array cannot be null.");
        }

        [Test]
        public void Transform_TransformerRuleIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Transformer().Transform(new[] { 1d, 2d }, null),
                "Transformer cannot be null.");
        }
        [Test]
        public void Transform_ArrayIsEmpty_ThrowArgumentException()
        {
            var transformationRule = new TransmerIEEE754();
            Assert.Throws<ArgumentException>(() => new Transformer().Transform(Array.Empty<double>(), transformationRule),
                "Array cannot be empty.");
        }
    }
}
