using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace HomeWorkRegexTests
{
    [TestClass]
    public class HomeWorkRegexExerciseTests
    {
        //3. An Internet company called retrofitness.com issues e-mail addresses to all employees.
        //The application that adds new employees to the database validates all data before entering it in the database.
        //Write a regular expression that permits the entry of a valid @retrofitness.com e-mail address where the address prefix may contain alphabetical, underscore, hyphen, and dot characters.
        //Note also that the first character in the e-mail address must be an alphabetical character.
        //prefix may contain alphabetical, underscore, hyphen, and dot characters
        [TestMethod]
        public void WhenUsingRegexPatternMatchesEmail()
        {
            var pattern = @"^[a-zA-Z][a-zA-Z_\.\-]*@(retrofitness\.)com$";
            var regexExpression = new Regex(pattern);

            var matchingWords = new List<string> { "a_m@retrofitness.com", "A@retrofitness.com" };
            var notMatchingWords = new List<string> { "a@retrofitness.com@retrofitness.com", "100@retrofitness.com", "89a@retrofitness.com", "m,m@retrofitness.com", "m?x@retrofitness.com"};

            foreach (string word in matchingWords)
            {
                Assert.IsTrue(regexExpression.IsMatch(word), $"{word} does not match regual expression.");
            }

            foreach (string word in notMatchingWords)
            {
                Assert.IsFalse(regexExpression.IsMatch(word), $"{word} matches regual expression.");
            }
        }



        //4. Write a regular expression that only permits an entry of either “Cable” or “DSL”.
        [TestMethod]
        public void WhenUsingRegexPatternMatchesOnlyCableOrDSL()
        {
            var pattern = @"(^(Cable|DSL)$)";
            var regexExpression = new Regex(pattern);

            var matchingWords = new List<string> { "Cable", "DSL" };
            var notMatchingWords = new List<string> { "CableCable", "cable", "DSLDSL", "dsl", "CableDSLCableDSL", "5G" };

            foreach (string word in matchingWords)
            {
                Assert.IsTrue(regexExpression.IsMatch(word), $"{word} does not match regual expression.");
            }

            foreach (string word in notMatchingWords)
            {
                Assert.IsFalse(regexExpression.IsMatch(word), $"{word} matches regual expression.");
            }
        }

        //5. Write a regular expression to ensure that an age string is valid for all numbers between “1” and “110”.


        [TestMethod]
        public void WhenUsingRegexPatternMatchesAgeRangeBetween1And110()
        {
            var pattern = @"(^[1-9]\d{0,1}$)|(^10\d{1}$)|110";
            var regexExpression = new Regex(pattern);

            var matchingNumbers = new List<string> { "1", "7", "9", "99", "100", "109", "110" };
            var notMatchingNumbers = new List<string> {"0", "012", "1000", "1000", "111"};

            foreach (string number in matchingNumbers)
            {
                Assert.IsTrue(regexExpression.IsMatch(number), $"{number} does not match regual expression.");
            }

            var result = regexExpression.IsMatch(notMatchingNumbers[0]);
            foreach (string number in notMatchingNumbers)
            {
                Assert.IsFalse(regexExpression.IsMatch(number), $"{number} matches regual expression.");
            }
        }

        //6.Write an expression that only validates phrases with two or more occurrences of the word substring “go”. Each occurrence of “go” is case insensitive.Sample valid strings include “Go dogs go” and “Ogopogo”.

        [TestMethod]
        public void WhenUsingRegexPatternMatchesGoSubstringInAWord()
        {
            var pattern = @"([a-z_A-z]*[\s\p{P}]*([gG]o)[a-z_A-z]*[\s\p{P}]*){2,}";
            var regexExpression = new Regex(pattern);

            var matchingSentences = new List<string> { "Go dogs go", "Ogopogo", "go, Go, go,", "there are 4 times: go go go go", "godmgs godxgs" };
            var notMatchingSentences = new List<string> { "godogs", "Go", "go", "I have a pet - go", "there is no such word" };

            foreach (string phrase in matchingSentences)
            {
                Assert.IsTrue(regexExpression.IsMatch(phrase), $"{phrase} does not match regual expression.");
            }

            foreach (string phrase in notMatchingSentences)
            {
                Assert.IsFalse(regexExpression.IsMatch(phrase), $"{phrase} matches regual expression.");
            }
        }

        //7. Write an expression to ensure that monetary amounts always begin with a “$” sign,
        //that at least one digit exists on the left side of the decimal point,
        //and that there are always two digits on the right side of the decimal point.
        [TestMethod]
        public void WhenUsingRegexPatternMatchesMonetaryPattern()
        {
            var pattern = @"^\$(0|([1-9]*)).([0-9]{2})$";
            var regexExpression = new Regex(pattern);

            var matchingMonetaryAmounts = new List<string> { "$0.00", "$123456789.96"};
            var notMatchingMonetaryAmounts = new List<string> { "0.00", "$0.0","$00000.00", "$0.0000000", "$0.0" };

            foreach (string phrase in matchingMonetaryAmounts)
            {
                Assert.IsTrue(regexExpression.IsMatch(phrase), $"{phrase} does not match regual expression.");
            }

            foreach (string phrase in notMatchingMonetaryAmounts)
            {
                Assert.IsFalse(regexExpression.IsMatch(phrase), $"{phrase} matches regual expression.");
            }
        }

        //8. Užrašykite regex išraišką, kuri atpažintų 24 val. laikrodį (nuo 00:00 iki 23:59).

        [TestMethod]
        public void WhenUsingRegexPatternMatchesClockPattern()
        {
            var pattern = @"^(([01][0-9])|([2][123])):([0-5][0-9])$";
            var regexExpression = new Regex(pattern);

            var matchingClockTimes = new List<string> { "00:00", "01:20", "23:59", "08:47" };
            var notMatchingClockTimes = new List<string> { "0:00", "0:0", "00000:00", "0:0000000", "08:80", "48:88" };

            foreach (string clockTime in matchingClockTimes)
            {
                Assert.IsTrue(regexExpression.IsMatch(clockTime), $"{clockTime} does not match regual expression.");
            }

            foreach (string clockTime in notMatchingClockTimes)
            {
                Assert.IsFalse(regexExpression.IsMatch(clockTime), $"{clockTime} matches regual expression.");
            }
        }
    }

}
