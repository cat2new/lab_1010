using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfLib
{
    public class IdNumber
    {
        public int number;

        public IdNumber() { number = 0; }
        public IdNumber(int number)
        {
            Number = number;
        }

        public int Number
        {
            get { return number; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("чистло меньше 0");

                }
                number = value;
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is IdNumber number &&
                   Number == number.Number;
        }
        public override string ToString()
        {
            return $"ID: {Number}";
        }
    }
}
