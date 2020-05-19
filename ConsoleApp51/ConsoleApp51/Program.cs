using System;
using System.Diagnostics;

namespace ConsoleApp51
{
    unsafe struct BitVector128
    {
        fixed uint values[4];

        public void Set(char c)
        {
            Debug.Assert(c < 128);
            values[c >> 5] |= (uint)1 << c;
        }

        public bool this[char c]
        {
            get
            {
                Debug.Assert(c < 128);
                return (values[c >> 5] & (uint)1 << c) != 0;
            }
        }
    }

    class Program
    {

        public bool Test()
        {
            bool fail = false;

            BitVector128 b = new BitVector128();

            for (int i = 0; i < 128; i++)
            {
                char c = Convert.ToChar(i);

                b.Set(c);

                for (int j = 0; j < 128; j++)
                {
                    char d = Convert.ToChar(j);

                    bool ret = b[d];

                    if (ret != (j <= i))
                    {
                        // do something
                        fail = true;
                    }
                }

            }

            b = new BitVector128();

            for (int i = 127; i >= 0; i--)
            {
                char c = Convert.ToChar(i);

                b.Set(c);

                for (int j = 0; j < 128; j++)
                {
                    char d = Convert.ToChar(j);

                    bool ret = b[d];

                    if (ret != (j >= i))
                    {
                        // do something
                        fail = true;
                    }
                }
            }



            for (int i = 127; i >= 0; i--)
            {
                b = new BitVector128();

                char c = Convert.ToChar(i);

                b.Set(c);

                for (int j = 0; j < 128; j++)
                {
                    char d = Convert.ToChar(j);

                    bool ret = b[d];

                    if (ret != (j == i))
                    {
                        // do something
                        fail = true;
                    }
                }
            }

            return !fail;
        }

        public static int Main()
        {
            Program p = new Program();
            bool ret = p.Test();
            return ret ? 100 : 500;
        }

    }
}
