using System;
using NUnit.Framework;

namespace StringCalculator.Tests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        private StringCalculator _stringCalculator;

        [SetUp]
        public void Init()
        {
            _stringCalculator = new StringCalculator();
        }

        [Test]
        public void CanInstantiateNewStringCalculator()
        {
            Assert.That(_stringCalculator, Is.TypeOf<StringCalculator>());
        }

        [Test]
        public void AddMethodReturnsZeroForEmptyString()
        {
            var result = _stringCalculator.Add("");

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void AddMethodReturnsCorrectNumberForASingleNumberInput()
        {
            var result = _stringCalculator.Add("1");

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void AddMethodSumsTwoCommaSeparatedNumbers()
        {
            var result = _stringCalculator.Add("1,1");

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void AddMethodSumsMultipleCommaSeparatedNumbers()
        {
            var result = _stringCalculator.Add("1,1,1");

            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void AddMethodCanAcceptNewlineCharactersInPlaceOfCommaSeparators()
        {
            var result = _stringCalculator.Add(@"1\n2,3");

            Assert.That(result, Is.EqualTo(6));
        }

        [Test]
        public void AddMethodAllowsDelimiterToBeSetByTheCaller()
        {
            var result = _stringCalculator.Add(@"//;\n1;2");

            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void AddMethodShouldThrowIfAnyNumberIsNegative()
        {
            var exception = Assert.Throws<Exception>(
                delegate { _stringCalculator.Add("1,-1"); });

            Assert.That(exception.Message, Is.EqualTo("negatives not allowed"));
        }

        [Test]
        public void AddMethodShouldIgnoreValuesGreaterThanOneThousand()
        {
            var result = _stringCalculator.Add("2,1001");

            Assert.That(result, Is.EqualTo(2));
        }
    }
}
