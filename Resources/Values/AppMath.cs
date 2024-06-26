using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMHYST.Resources.Values
{
    class AppMath
    {
        public int calculateCombination(int n, int k)
        {
            return calculateFactorial(n) / (calculateFactorial(k) * calculateFactorial(n - k));
        }

        public int calculateFactorial(int n)
        {
            int result = 1;

            if (n < 1)
            {
                result = 1;
            }
            else for (int i = 1; i <= n; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}