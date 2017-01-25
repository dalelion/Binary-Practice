using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing {

    class Binary {

        public long Value;

        public Binary(long v) {
            Value = v;
        }

        public static implicit operator Binary(long value) {
            return new Binary(value);
        }

        //TODO: make binary addition method.
        public static Binary operator +(Binary num1, Binary num2) {
            return Binary.ToBinary(num1.ToInt() + num2.ToInt());
        }

        public Binary Flip() {
            return null;
        }

        public static Binary ToBinary (int NumToConvert) {
            int Count = 0;
            String Result = "";

            while (NumToConvert > 0) {
                ++Count;
                //Result = Count % 4 == 0 ? " " + NumToConvert % 2 + Result : NumToConvert % 2 + Result; //was used for strings
                Result = NumToConvert % 2 + Result;
                NumToConvert /= 2;
            }
            return new Binary(Convert.ToInt64(Result));
        }

        public int ToInt () {
            int Result = 0, Count = 0;

            foreach (char x in this.ToString().Reverse()) {
                Result += x.Equals('1') ? Int32.Parse(x.ToString()) * (int)Math.Pow(2, Count) : 0;
                //if (x != ' ') //uncomment if you want to allow spaces with strings again
                ++Count;
            }
            return Result;
        }

        public override String ToString () {
            return "" + this.Value;
        }


    }

    class Program {
        static void Main (string[] args) {

            Binary x = 10110;
            Binary y = 100010101;

            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.WriteLine(x + y);

            Console.ReadKey();
        }
    }
}