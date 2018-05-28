using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryTestTasks.Tests
{
    [TestClass]
    public class RomanNumeralsConverterTests
    {
        [TestMethod]
        public void CheckRomanSymbols_MMMD_true_returned()
        {
            string str = "MMD";
            bool expected = true;

            RomanNumeralsConverter romanNumerals = RomanNumeralsConverter.GetConverter();
            bool actual = romanNumerals.CheckRomanSymbols(str);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CheckRomanSymbols_extra_character_false_returned()
        {
            string str = "MMMDW";
            bool expected = false;

            RomanNumeralsConverter romanNumerals = RomanNumeralsConverter.GetConverter();
            bool actual = romanNumerals.CheckRomanSymbols(str);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckSubstructionInside_subtractions_exceeded_false_returned()
        {
            string str = "MMMIIX";
            bool expected = false;

            RomanNumeralsConverter romanNumerals = RomanNumeralsConverter.GetConverter();
            bool actual = romanNumerals.CheckSubstructionInside(str);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckSubstructionInside_not_power_ten_exceeded_false_returned()
        {
            string str = "MMMVX";
            bool expected = false;

            RomanNumeralsConverter romanNumerals = RomanNumeralsConverter.GetConverter();
            bool actual = romanNumerals.CheckSubstructionInside(str);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CheckSubstructionInside_not_correspond_number_series_false_returned()
        {
            string str = "MMIMX";
            bool expected = false;

            RomanNumeralsConverter romanNumerals = RomanNumeralsConverter.GetConverter();
            bool actual = romanNumerals.CheckSubstructionInside(str);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CheckDuplicateChars_incorrect_false_returned()
        {
            string str = "MMMMIMX";
            bool expected = false;

            RomanNumeralsConverter romanNumerals = RomanNumeralsConverter.GetConverter();
            bool actual = romanNumerals.CheckDuplicateChars(str);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ConvertRomanToInt_correct_number_true_returned()
        {
            string str = "MMMCMXCIX";
            int expected = 3999;

            RomanNumeralsConverter romanNumerals = RomanNumeralsConverter.GetConverter();
            int actual = romanNumerals.ConvertRomanToInt(str, null);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ConvertRomanToInt_limit_3000_3000_returned()
        {
            string str = "MMMCMXCIX";
            int expected = 3000;

            RomanNumeralsConverter romanNumerals = RomanNumeralsConverter.GetConverter();
            int actual = romanNumerals.RomanToInt(str, (result)=> result >= 3000);

            Assert.AreEqual(expected, actual);
        }
    }
}
