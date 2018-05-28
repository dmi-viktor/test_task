using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LibraryTestTasks
{
    public interface IMessanger
    {
        void ShowError(string message);
        void ShowWarning(string message);
    }

    public class ConsoleWriter : IMessanger
    {
        public void ShowError(string message)
        {
            Console.WriteLine("Error: {0}", message);
        }
        public void ShowWarning(string message)
        {
            Console.WriteLine("Warning: {0}", message);
        }
    }

    public class RomanNumeralsConverter
    {
        private static RomanNumeralsConverter romanNumeralConverter;
        private IMessanger messanger;

        public static RomanNumeralsConverter GetConverter()
        {
            if (romanNumeralConverter == null)
            {
                romanNumeralConverter = new RomanNumeralsConverter();
            }
            return romanNumeralConverter;
        }

        public void SetMessanger(IMessanger messanger)
        {
            this.messanger = messanger;
        }

        protected Dictionary<char, int> GetRomanNumbers()
        {
            Dictionary<char, int> roman_numbers = new Dictionary<char, int>() {
                    { 'I', 1 },
                    { 'V', 5 },
                    { 'X', 10 },
                    { 'L', 50 },
                    { 'C', 100},
                    { 'D', 500},
                    { 'M', 1000} };
            return roman_numbers;
        }
        protected Dictionary<char, int> GetCountSymbolRepetitions()
        {
            Dictionary<char, int> count_symbol_repetitions = new Dictionary<char, int>() {
                    { 'I', 3 },
                    { 'V', 1 },
                    { 'X', 3 },
                    { 'L', 1 },
                    { 'C', 3},
                    { 'D', 1},
                    { 'M', 3} };
            return count_symbol_repetitions;
        }

        public bool CheckRomanSymbols(string s)
        {
            char[] roman_symbols = GetRomanNumbers().Select(number => number.Key).ToArray();
            string pattern = string.Format("[^{0}]", new string(roman_symbols));
            bool contains_extra_chars = Regex.IsMatch(s, pattern);
            return !contains_extra_chars;
        }

        public bool CheckSubstructionInside(string s)
        {
            Dictionary<char, int> roman_numbers = GetRomanNumbers();

            int count_substruction = 0;
            int previous_value = 0;
            int current_value = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                current_value = roman_numbers[s[i]];

                if (current_value < previous_value)
                {
                    if (Math.Truncate(Math.Log(current_value, 10)) != Math.Log(current_value, 10))
                    {
                        messanger?.ShowError("is not a power of 10");
                        return false;
                    }
                    if (previous_value != current_value * 10 &&
                        current_value / 10 * 5 != previous_value / 10)
                    {
                        messanger?.ShowError("does not correspond to a number series");
                        return false;
                    }
                    count_substruction++;
                }
                else if (current_value == previous_value && count_substruction > 0)
                {
                    messanger?.ShowError("the number of subtractions exceeded");
                    return false;
                }
                else
                {
                    count_substruction = 0;
                }
                previous_value = current_value;
            }
            return true;
        }
        public bool CheckDuplicateChars(string s)
        {
            Dictionary<char, int> count_symbol_repetitions = GetCountSymbolRepetitions();
            int count_repetitions = 0;
            char current_symbol = s[0];
            for (int i = 0; i < s.Length; i++)
            {
                if (current_symbol == s[i])
                {
                    count_repetitions++;
                    if (count_repetitions > count_symbol_repetitions[current_symbol])
                    {
                        return false;
                    }
                }
                else
                {
                    current_symbol = s[i];
                    count_repetitions = 1;
                }
            }
            return true;
        }

        public int RomanToInt(string s)
        {
            return RomanToInt(s, null);
        }

        public int RomanToInt(string s, Predicate<int> output_limitation)
        {
            s = s.ToUpper();
            if (!CheckRomanSymbols(s))
            {
                messanger?.ShowError("these are not Roman numeral");
                return 0;
            }
            if (!CheckSubstructionInside(s))
            {
                return 0;
            }
            if (!CheckDuplicateChars(s))
            {
                messanger?.ShowError("exceeded the allowed number of repetitions");
                return 0;
            }
            return ConvertRomanToInt(s, output_limitation);
        }

        public int ConvertRomanToInt(string s, Predicate<int> output_limitation)
        {
            Dictionary<char, int> roman_numbers = GetRomanNumbers();

            int result_value = 0;
            int current_value = 0;
            int next_value = 0;
            for (int i = 0; i < s.Length; i++)
            {
                current_value = roman_numbers[s[i]];
                next_value = (i < s.Length - 1) ? roman_numbers[s[i + 1]] : 0;
                result_value += (current_value >= next_value) ? current_value : -current_value;
                if (output_limitation?.Invoke(result_value) ?? false)
                {
                    messanger?.ShowWarning("output is limited");
                    return result_value;
                }
            }
            return result_value;
        }
    }
}
