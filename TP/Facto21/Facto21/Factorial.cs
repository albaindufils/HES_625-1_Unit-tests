using System;
using System.Collections.Generic;
using System.Text;

namespace Facto21
{
    public class Factorial
    {
        public int TheResult { get; set; }
        int inOverflow;
        public void Compute(int inputValue)
        {
            if (inputValue < 0)
            {
                TheResult = -1;
                return;
            }
            if (inputValue == 0)
            {
                TheResult = 0;
                return;
            }
            TheResult = 1;
            for (int i = 1; i <= inputValue; i++)
            {
                inOverflow = TheResult;
                TheResult = TheResult * i;
                if (inOverflow != (TheResult / i))
                {
                    TheResult = -2;
                    break;
                }
            }
        }
    }
}
