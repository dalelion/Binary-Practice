using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing {

    class Binary {

        public ulong Value;

        public Binary (ulong v) {
            Value = v;
        }

        public static implicit operator Binary (ulong value) {
            return new Binary(value);
        }

        //TODO: make binary addition method.
        public static Binary operator + (Binary num1, Binary num2) {
            return Binary.ToBinary(num1.ToBase10() + num2.ToBase10());
        }

        public Binary Flip () {
            return null;
        }

        public static Binary ToBinary (ulong NumToConvert) {
            int Count = 0;
            String Result = "";

            while (NumToConvert > 0) {
                ++Count;
                //Result = Count % 4 == 0 ? " " + NumToConvert % 2 + Result : NumToConvert % 2 + Result; //was used for strings
                Result = NumToConvert % 2 + Result;
                NumToConvert /= 2;
            }
            return new Binary(Convert.ToUInt64(Result));
        }

        public ulong ToBase10 () {
            ulong Result = 0, Count = 0;

            foreach (char x in this.ToString().Reverse()) {
                Result += x.Equals('1') ? UInt64.Parse(x.ToString()) * (ulong)Math.Pow(2, Count) : 0;
                //if (x != ' ') //uncomment if you want to allow spaces with strings again
                ++Count;
            }
            return Result;
        }

        public override String ToString () {
            return String.Format("{0}", this.Value);
        }

    }

    class Program {
        static void Main (string[] args) {

            Binary x = 10110;
            Binary y = 100010101;

            Console.WriteLine(x);
            Console.WriteLine(x.ToBase10());

            Console.WriteLine(y);
            Console.WriteLine(y.ToBase10());

            Binary z = (x + y);
            Console.WriteLine(z);
            Console.WriteLine(z.ToBase10());

            Console.ReadKey();
        }
    }
}