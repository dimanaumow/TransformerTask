using TransformerStrategy.TransformerImplementation;
using TransformerStrategy;
using NUnit.Framework;
using System;

namespace TransformerStrategyTest.NUnitTests
{
    public class TransformerWithIEEETransformerTests
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
        public string[] Transform_ToIEEE_Tests(double[] source)
        {
            var transformationRule = new TransmerIEEE754();
            var transformer = new Transformer();
            return transformer.Transform(source, transformationRule);
        }
    }
}
