using System;
using System.Collections.Generic;
using NUnit.Framework;
using static Delegates.FunctionExtensions;

namespace Delegates.Tests
{
    [TestFixture]
    public class FunctionExtensionsTests
    {
        [TestCaseSource(typeof(DataSourceForTests),
            nameof(DataSourceForTests.DataForGenerateProgressionTestForIntegers))]
        [Category(nameof(GenerateProgression))]
        public void GenerateProgression_Generate_Integer_Elements_Progression(int first, Func<int, int> formula,
            int count, List<int> expected)
        {
            CollectionAssert.AreEqual(expected, GenerateProgression(first, formula, count));
        }

        [TestCaseSource(typeof(DataSourceForTests),
            nameof(DataSourceForTests.DataForGenerateProgressionTestForDoubles))]
        [Category(nameof(GenerateProgression))]
        public void GenerateProgression_Generate_Double_Elements_Progression(double first, Func<double, double> formula,
            int count,
            List<double> expected)
        {
            CollectionAssert.AreEqual(expected, GenerateProgression(first, formula, count), Comparer<double>.Create(
                (x, y) => (Math.Abs(y - x) > DataSourceForTests.Accuracy)
                    ? 1
                    : ((Math.Abs(x - y) > DataSourceForTests.Accuracy) ? -1 : 0)));
        }

        [Test]
        [Category(nameof(GenerateProgression))]
        public void GenerateProgression_Formula_Is_Null_Throw_ArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => GenerateProgression(0, null, 1));

        [Test]
        [Category(nameof(GenerateProgression))]
        public void GenerateProgression_Count_Is_0_Throw_ArgumentOutOfRangeException()
            => Assert.Throws<ArgumentOutOfRangeException>(() => GenerateProgression(0, x => x, 0));

        [Test]
        [Category(nameof(GenerateProgression))]
        public void GenerateProgression_Count_Is_Less_Than_0_Throw_ArgumentOutOfRangeException()
            => Assert.Throws<ArgumentOutOfRangeException>(() => GenerateProgression(0, x => x, -10));

        [TestCaseSource(typeof(DataSourceForTests),
            nameof(DataSourceForTests.DataForGenerateProgressionTestWithConditionForIntegers))]
        [Category(nameof(GenerateProgression))]
        public void GenerateProgression_With_Predicate_Generate_Integer_Elements_Progression(int first,
            Func<int, int> formula, Predicate<int> finished,
            List<int> expected)
        {
            CollectionAssert.AreEqual(expected, GenerateProgression(first, formula, finished));
        }

        [TestCaseSource(typeof(DataSourceForTests),
            nameof(DataSourceForTests.DataForGenerateProgressionWithConditionTestForDoubles))]
        [Category(nameof(GenerateProgression))]
        public void GenerateProgression_With_Predicate_Generate_Double_Elements_Progression(double first,
            Func<double, double> formula, Predicate<double> finished,
            List<double> expected)
        {
            CollectionAssert.AreEqual(expected, GenerateProgression(first, formula, finished), Comparer<double>.Create(
                (x, y) => (Math.Abs(y - x) > DataSourceForTests.Accuracy)
                    ? 1
                    : ((Math.Abs(x - y) > DataSourceForTests.Accuracy) ? -1 : 0)));
        }

        [Test]
        [Category(nameof(GenerateProgression))]
        public void GenerateProgression_With_Predicate_Formula_Is_Null_Throw_ArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => GenerateProgression(0, null, x => true));

        [Test]
        [Category(nameof(GenerateProgression))]
        public void GenerateProgression_With_Predicate_Predicate_Is_Null_Throw_ArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => GenerateProgression(0, x => x, null));

        [TestCaseSource(typeof(DataSourceForTests), nameof(DataSourceForTests.DataForGetElementTestForIntegers))]
        [Category(nameof(GetElement))]
        public void GetElement_Get_Integer_Element(int first, Func<int, int> formula, int number, int expected)
        {
            Assert.AreEqual(expected, GetElement(first, formula, number));
        }

        [TestCaseSource(typeof(DataSourceForTests), nameof(DataSourceForTests.DataForGetElementTestForDoubles))]
        [Category(nameof(GetElement))]
        public void GetElement_Get_Double_Element(double first, Func<double, double> formula, int number,
            double expected)
        {
            Assert.AreEqual(expected, GetElement(first, formula, number), DataSourceForTests.Accuracy);
        }

        [Test]
        [Category(nameof(GetElement))]
        public void GetElement_Formula_Is_Null_Throw_ArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => GetElement(0, null, 1));

        [Test]
        [Category(nameof(GetElement))]
        public void GetElement_Count_Is_Less_Than_0_Throw_ArgumentOutOfRangeException()
            => Assert.Throws<ArgumentOutOfRangeException>(() => GetElement(0, x => x, -1));

        [Test]
        [Category(nameof(GetElement))]
        public void GetElement_Count_Is_0_Throw_ArgumentOutOfRangeException()
            => Assert.Throws<ArgumentOutOfRangeException>(() => GetElement(0, x => x, 0));

        [TestCaseSource(typeof(DataSourceForTests), nameof(DataSourceForTests.DataForGenerateSequenceTestForIntegers))]
        [Category(nameof(GenerateSequence))]
        public void GenerateSequence_Generate_Integer_Elements_Sequence(int first, int second,
            Func<int, int, int> formula, int count, List<int> expected)
        {
            CollectionAssert.AreEqual(expected, GenerateSequence(first, second, formula, count));
        }

        [TestCaseSource(typeof(DataSourceForTests), nameof(DataSourceForTests.DataForGenerateSequenceTestForDoubles))]
        [Category(nameof(GenerateSequence))]
        public void GenerateSequence_Generate_Double_Elements_Sequence(double first, double second,
            Func<double, double, double> formula, int count,
            List<double> expected)
        {
            CollectionAssert.AreEqual(expected, GenerateSequence(1, 2, formula, count),
                Comparer<double>.Create((x, y) =>
                    (Math.Abs(y - x) > DataSourceForTests.Accuracy)
                        ? 1
                        : ((Math.Abs(x - y) > DataSourceForTests.Accuracy) ? -1 : 0)));
        }

        [Test]
        [Category(nameof(GenerateSequence))]
        public void GenerateSequence_Count_Less_Or_Equal_Zero_Throw_ArgumentOutOfRangeException() =>
            Assert.Throws<ArgumentOutOfRangeException>(() => GenerateSequence(1, 1, (a, b) => b + a, -12));

        [TestCase(2, true)]
        [TestCase(-5, true)]
        [TestCase(9, true)]
        [TestCase(-20, false)]
        [TestCase(0, false)]
        [TestCase(1, false)]
        [Category(nameof(CombinePredicates))]
        public void CombinePredicates_Combine_Integer_Predicates(int value, bool status)
        {
            var result = CombinePredicates<int>(
                x => x > -10,
                x => x < 10,
                x => x != 0,
                x => x != 1);

            Assert.That(result(value) == status);
        }

        [TestCase("START # END", true)]
        [TestCase("START######END", true)]
        [TestCase("START 1111#1111 END", true)]
        [TestCase("START END", false)]
        [TestCase("", false)]
        [TestCase("START #", false)]
        [Category(nameof(CombinePredicates))]
        public void CombinePredicates_Combine_String_Predicates(string value, bool status)
        {
            var result = CombinePredicates<string>(
                x => !string.IsNullOrEmpty(x),
                x => x.StartsWith("START"),
                x => x.EndsWith("END"),
                x => x.Contains("#"));

            Assert.That(result(value) == status);
        }

        [Test]
        [Category(nameof(CombinePredicates))]
        public void CombinePredicates_Predicate_Is_Null_Throw_ArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => CombinePredicates<int>(null));

        [TestCaseSource(typeof(DataSourceForTests), nameof(DataSourceForTests.DataForFindMaxTestForIntegers))]
        [Category(nameof(FindMax))]
        public void FindMax_From_Integer_Numbers(int lhs, int rhs, Comparison<int> comparer, int expected)
        {
            Assert.That(FindMax(lhs, rhs, comparer) == expected);
        }

        [TestCaseSource(typeof(DataSourceForTests), nameof(DataSourceForTests.DataForFindMaxTestForDoubles))]
        [Category(nameof(FindMax))]
        public void FindMax_From_Double_Numbers(double lhs, double rhs, Comparison<double> comparer, double expected)
        {
            Assert.AreEqual(expected, FindMax(lhs, rhs, comparer), DataSourceForTests.Accuracy);
        }

        [TestCaseSource(typeof(DataSourceForTests), nameof(DataSourceForTests.DataForFindMaxTestForStrings))]
        [Category(nameof(FindMax))]
        public void FindMax_From_Strings(string lhs, string rhs, Comparison<string> comparer, string expected)
        {
            Assert.That(FindMax(lhs, rhs, comparer) == expected);
        }

        [Test]
        [Category(nameof(FindMax))]
        public void FindMax_Comparer_Is_Null_Throw_ArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => FindMax(-12, 12, null));

        [TestCaseSource(typeof(DataSourceForTests), nameof(DataSourceForTests.DataForCalculateTestForIntegers))]
        [Category(nameof(Calculate))]
        public void Calculate_Calculate_For_Integer_Elements(int first, Func<int, int> formula,
            Func<int, int, int> operation, int count, int expected)
        {
            Assert.That(Calculate(first, formula, operation, count) == expected);
        }

        [TestCaseSource(typeof(DataSourceForTests), nameof(DataSourceForTests.DataForCalculateTestForDoubles))]
        [Category(nameof(Calculate))]
        public void Calculate_Calculate_For_Double_Elements(double first, Func<double, double> formula,
            Func<double, double, double> operation, int count, double expected)
        {
            Assert.AreEqual(expected, Calculate(first, formula, operation, count), DataSourceForTests.Accuracy);
        }

        [Test]
        [Category(nameof(Calculate))]
        public void Calculate_Formula_Is_Null_Throw_ArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => Calculate(1, null, (x, y) => x + y, 6));

        [Test]
        [Category(nameof(Calculate))]
        public void Calculate_Operation_Is_Null_Throw_ArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => Calculate(1, x => x, null, 6));

        [Test]
        [Category(nameof(Calculate))]
        public void Calculate_Count_Is_0_Throw_ArgumentOutOfRangeException()
            => Assert.Throws<ArgumentOutOfRangeException>(() => Calculate(0, x => x, (x, y) => x + y, 0));

        [Test]
        [Category(nameof(Calculate))]
        public void Calculate_Count_Is_Less_Than_0_Throw_ArgumentOutOfRangeException()
            => Assert.Throws<ArgumentOutOfRangeException>(() => Calculate(0, x => x, (x, y) => x + y, -10));
    }
}
