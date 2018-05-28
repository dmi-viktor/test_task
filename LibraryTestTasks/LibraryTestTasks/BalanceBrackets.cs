using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTestTasks
{
    public class BalanceBrackets
    {
        private static BalanceBrackets balanceBrackets;
        public static BalanceBrackets GetBalanceBrackets()
        {
            if (balanceBrackets == null)
                balanceBrackets = new BalanceBrackets();
            return balanceBrackets;
        }

        public bool CheckBalanceRoundBrackets(string s)
        {
            return CheckBalanceBrackets(s, '(', ')');
        }

        public bool CheckBalanceBrackets(string s, char open_brackets, char close_brackets)
        {
            int balance_ratio = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == open_brackets)
                {
                    balance_ratio++;
                }
                else if (s[i] == close_brackets)
                {
                    balance_ratio--;
                }
                if (balance_ratio < 0)
                    return false;
            }
            return balance_ratio == 0;
        }
    }
}
