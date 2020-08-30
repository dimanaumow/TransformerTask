using NUnit.Framework;
using System;
using System.Linq;
using TransformerToIEEEPartial;

namespace TransformerPartialTests.TransformerToIEEETests
{
    [TestFixture]
    public class TransformerTest
    {
        [TestCase(new[] { 122.625, -255.255, 255.255, 4294967295.012, -451387.2345, 0.2345E-12 },
           ExpectedResult = new[]
           {
                "0100000001011110101010000000000000000000000000000000000000000000",
                "1100000001101111111010000010100011110101110000101000111101011100",
                "0100000001101111111010000010100011110101110000101000111101011100",
                "0100000111101111111111111111111111111111111000000110001001001110",
                "1100000100011011100011001110110011110000001000001100010010011100",
                "0011110101010000100000000110000001011111000011101110100001011011",
           })]
        [TestCase(new[] { double.PositiveInfinity, 0.0, double.NegativeInfinity, -0.0, double.Epsilon, double.NaN },
           ExpectedResult = new[]
           {
                "0111111111110000000000000000000000000000000000000000000000000000",
                "0000000000000000000000000000000000000000000000000000000000000000",
                "1111111111110000000000000000000000000000000000000000000000000000",
                "1000000000000000000000000000000000000000000000000000000000000000",
                "0000000000000000000000000000000000000000000000000000000000000001",
                "1111111111111000000000000000000000000000000000000000000000000000",
           })]
        public string[] TransformerWithCorrectDoubleArrayTests(double[] source)
        {
            var transformer = new Transformer();
            return transformer.Transform(source);
        }

        [Test]
        public void Transform_ArrayIsNull_ThrowArgumentNullException() => Assert.Throws<ArgumentNullException>(
           () => new Transformer().Transform(null), "Array cannot be null.");

        [Test]
        public void Transform_ArrayIsEmpty_ThrowArgumentException() => Assert.Throws<ArgumentException>(
            () => new Transformer().Transform(Array.Empty<double>()), "Array cannot be empty.");

        [Timeout(2_500)]
        [Order(1)]
        [Test]
        public void Transform_PerformanceTest()
        {
            const int sourceLenght = 1_000_000;

            double[] source = Enumerable.Repeat(122.625, sourceLenght).ToArray();

            string[] expected = Enumerable.Repeat("0100000001011110101010000000000000000000000000000000000000000000", sourceLenght).ToArray();

            var transformer = new Transformer();
            string[] actual = transformer.Transform(source);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
