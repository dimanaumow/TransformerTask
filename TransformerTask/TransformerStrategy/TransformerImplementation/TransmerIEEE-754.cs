using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace TransformerStrategy.TransformerImplementation
{
    public class TransmerIEEE_754 : ITransformer
    {
        public const int bits = 8;
        public string Transform(double item)
        {
            var converter = new ConvertDoubleToLong() { Double64Bits = item };
            long longNumber = converter.Long64Bits;


            var result = new StringBuilder(sizeof(long) * bits);
            long mask = 0b_00000000_00000000_00000000_00000000_00000000_00000000_00000000_00000001;
            mask = mask << sizeof(long) * bits - 1;
            long sample = mask;
            long temp;
            string twoBits = "01";

            for (int i = 0; i < sizeof(long) * bits; i++)
            {
                temp = mask & longNumber;
                temp = temp << i;

                result.Append(twoBits[temp == sample ? 1 : 0]);

                mask = mask >> 1;
            }

            return result.ToString();
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct ConvertDoubleToLong
        {
            [FieldOffset(0)]
            private double double64Bits;
            [FieldOffset(0)]
            private long long64Bits;

            public double Double64Bits
            {
                set
                {
                    this.double64Bits = value;
                }
            }

            public long Long64Bits
             => this.long64Bits;
        }
    }
}
