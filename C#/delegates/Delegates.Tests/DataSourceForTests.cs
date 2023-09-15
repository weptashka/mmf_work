using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Delegates.Tests
{
    internal class DataSourceForTests
    {
        internal const double Accuracy = 10E-6;

        public static IEnumerable<TestCaseData> DataForGenerateProgressionTestForIntegers
        {
            get
            {
                yield return new TestCaseData(
                    1,
                    new Func<int, int>(current => current + 4),
                    20,
                    new List<int>
                    {
                        1,
                        5,
                        9,
                        13,
                        17,
                        21,
                        25,
                        29,
                        33,
                        37,
                        41,
                        45,
                        49,
                        53,
                        57,
                        61,
                        65,
                        69,
                        73,
                        77,
                    });
                yield return new TestCaseData(
                    10,
                    new Func<int, int>(current => current + 5),
                    10,
                    new List<int>
                    {
                        10,
                        15,
                        20,
                        25,
                        30,
                        35,
                        40,
                        45,
                        50,
                        55,
                    });
                yield return new TestCaseData(
                    1,
                    new Func<int, int>(current => 2 * current),
                    15,
                    new List<int>
                    {
                        1,
                        2,
                        4,
                        8,
                        16,
                        32,
                        64,
                        128,
                        256,
                        512,
                        1024,
                        2048,
                        4096,
                        8192,
                        16384,
                    });
            }
        }

        public static IEnumerable<TestCaseData> DataForGenerateProgressionTestForDoubles
        {
            get
            {
                yield return new TestCaseData(
                    0.4,
                    new Func<double, double>(current => current + 0.2),
                    13,
                    new List<double>
                    {
                        0.4,
                        0.6000000000000001,
                        0.8,
                        1,
                        1.2,
                        1.4,
                        1.5999999999999999,
                        1.7999999999999998,
                        1.9999999999999998,
                        2.1999999999999997,
                        2.4,
                        2.6,
                        2.8000000000000003,
                    });
                yield return new TestCaseData(
                    0.11,
                    new Func<double, double>(current => 1.25 * current),
                    10,
                    new List<double>
                    {
                        0.11,
                        0.1375,
                        0.171875,
                        0.21484375,
                        0.2685546875,
                        0.335693359375,
                        0.41961669921875,
                        0.5245208740234375,
                        0.6556510925292969,
                        0.8195638656616211,
                    });
            }
        }

        public static IEnumerable<TestCaseData> DataForGenerateProgressionTestWithConditionForIntegers
        {
            get
            {
                yield return new TestCaseData(
                    1,
                    new Func<int, int>(current => current + 4),
                    new Predicate<int>(current => current > 50),
                    new List<int>
                    {
                        1,
                        5,
                        9,
                        13,
                        17,
                        21,
                        25,
                        29,
                        33,
                        37,
                        41,
                        45,
                        49,
                    });
                yield return new TestCaseData(
                    10,
                    new Func<int, int>(current => current + 5),
                    new Predicate<int>(current => current / 10 == 10),
                    new List<int>
                    {
                        10,
                        15,
                        20,
                        25,
                        30,
                        35,
                        40,
                        45,
                        50,
                        55,
                        60,
                        65,
                        70,
                        75,
                        80,
                        85,
                        90,
                        95,
                    });
                yield return new TestCaseData(
                    1,
                    new Func<int, int>(current => 2 * current),
                    new Predicate<int>(current => current % 100 == 24),
                    new List<int>
                    {
                        1,
                        2,
                        4,
                        8,
                        16,
                        32,
                        64,
                        128,
                        256,
                        512,
                    });
            }
        }

        public static IEnumerable<TestCaseData> DataForGenerateProgressionWithConditionTestForDoubles
        {
            get
            {
                yield return new TestCaseData(
                    0.4,
                    new Func<double, double>(current => current + 0.2),
                    new Predicate<double>(current => current > 2.0),
                    new List<double>
                    {
                        0.4,
                        0.6000000000000001,
                        0.8,
                        1,
                        1.2,
                        1.4,
                        1.5999999999999999,
                        1.7999999999999998,
                        1.9999999999999998,
                    });
                yield return new TestCaseData(
                    0.11,
                    new Func<double, double>(current => 1.25 * current),
                    new Predicate<double>(current => current > 0.5),
                    new List<double>
                    {
                        0.11,
                        0.1375,
                        0.171875,
                        0.21484375,
                        0.2685546875,
                        0.335693359375,
                        0.41961669921875,
                    });
            }
        }

        public static IEnumerable<TestCaseData> DataForGetElementTestForIntegers
        {
            get
            {
                yield return new TestCaseData(
                    1,
                    new Func<int, int>(current => current + 4),
                    5,
                    17);
                yield return new TestCaseData(
                    10,
                    new Func<int, int>(current => current + 5),
                    10,
                    55);
                yield return new TestCaseData(
                    1,
                    new Func<int, int>(current => 2 * current),
                    10,
                    512);
            }
        }

        public static IEnumerable<TestCaseData> DataForGetElementTestForDoubles
        {
            get
            {
                yield return new TestCaseData(
                    0.4,
                    new Func<double, double>(current => current + 0.2),
                    13,
                    2.8000000000000003);
                yield return new TestCaseData(
                    0.11,
                    new Func<double, double>(current => 1.25 * current),
                    5,
                    0.2685546875);
            }
        }

        public static IEnumerable<TestCaseData> DataForGenerateSequenceTestForIntegers
        {
            get
            {
                yield return new TestCaseData(
                    1, 1,
                    new Func<int, int, int>((a, b) => b + a),
                    10,
                    new List<int>
                    {
                        1,
                        1,
                        2,
                        3,
                        5,
                        8,
                        13,
                        21,
                        34,
                        55
                    });
                yield return new TestCaseData(
                    1, 1,
                    new Func<int, int, int>((a, b) => b + a),
                    20,
                    new List<int>
                    {
                        1,
                        1,
                        2,
                        3,
                        5,
                        8,
                        13,
                        21,
                        34,
                        55,
                        89,
                        144,
                        233,
                        377,
                        610,
                        987,
                        1597,
                        2584,
                        4181,
                        6765
                    });
                yield return new TestCaseData(
                    1, 2,
                    new Func<int, int, int>((a, b) => 6 * b - 8 * a),
                    10,
                    new List<int>
                    {
                        1,
                        2,
                        4,
                        8,
                        16,
                        32,
                        64,
                        128,
                        256,
                        512
                    });
                yield return new TestCaseData(
                    1, 2,
                    new Func<int, int, int>((a, b) => 6 * b - 8 * a),
                    20,
                    new List<int>
                    {
                        1,
                        2,
                        4,
                        8,
                        16,
                        32,
                        64,
                        128,
                        256,
                        512,
                        1024,
                        2048,
                        4096,
                        8192,
                        16384,
                        32768,
                        65536,
                        131072,
                        262144,
                        524288
                    });
            }
        }

        public static IEnumerable<TestCaseData> DataForGenerateSequenceTestForDoubles
        {
            get
            {
                yield return new TestCaseData(
                    1, 2,
                    new Func<double, double, double>((a, b) => b + a / b),
                    10,
                    new List<double>
                    {
                        1,
                        2,
                        2.5,
                        3.3,
                        4.057575757575758,
                        4.870869260189648,
                        5.7038983440821145,
                        6.557852774255866,
                        7.427634170763254,
                        8.310533439021372
                    });
                yield return new TestCaseData(
                    1, 2,
                    new Func<double, double, double>((a, b) => b + a / b),
                    20,
                    new List<double>
                    {
                        1,
                        2,
                        2.5,
                        3.3,
                        4.057575757575758,
                        4.870869260189648,
                        5.7038983440821145,
                        6.557852774255866,
                        7.427634170763254,
                        8.310533439021372,
                        9.204294859423996,
                        10.107192209622688,
                        11.01786004580581,
                        11.935206260733473,
                        12.858345736090032,
                        13.7865527158755,
                        14.719225734365711,
                        15.655861462676294,
                        16.59603494143736,
                        17.539384453409426
                    });
            }
        }

        public static IEnumerable<TestCaseData> DataForFindMaxTestForIntegers
        {
            get
            {
                yield return new TestCaseData(
                    1, -20, new Comparison<int>((a, b) => a.CompareTo(b)), 1);
                yield return new TestCaseData(
                    1, -20, new Comparison<int>((a, b) => Math.Abs(a).CompareTo(Math.Abs(b))), -20);
                yield return new TestCaseData(
                    2_119, 2_787, new Comparison<int>((a, b) => a % 10 - b % 10), 2_119);
            }
        }
        
        public static IEnumerable<TestCaseData> DataForFindMaxTestForStrings
        {
            get
            {
                yield return new TestCaseData(
                    "four", "six", new Comparison<string>((a, b) => string.Compare(a, b, StringComparison.Ordinal)), "six");
                yield return new TestCaseData(
                    "four", "six", new Comparison<string>((a, b) => a.Length.CompareTo(b.Length)), "four");
                yield return new TestCaseData(
                    "Four", "six", new Comparison<string>((a, b) => string.Compare(a, b, StringComparison.OrdinalIgnoreCase)), "six");
                yield return new TestCaseData(
                    "Four", "four", new Comparison<string>((a, b) => string.Compare(a, b, StringComparison.InvariantCulture)), "Four");
                yield return new TestCaseData(
                    "Four", "four", new Comparison<string>((a, b) => string.Compare(a, b, StringComparison.Ordinal)), "four");
            }
        }
        
        public static IEnumerable<TestCaseData> DataForFindMaxTestForDoubles
        {
            get
            {
                yield return new TestCaseData(
                    0.0001, 12.456, new Comparison<double>((a, b) => a.CompareTo(b)), 12.456);
                yield return new TestCaseData(
                    0.0001, -12.456, new Comparison<double>((a, b) => a.CompareTo(b)), 0.0001);
                yield return new TestCaseData(
                    0.0001, -12.456, new Comparison<double>((a, b) => Math.Abs(a).CompareTo(Math.Abs(b))), -12.456);
            }
        }

        public static IEnumerable<TestCaseData> DataForCalculateTestForIntegers
        {
            get
            {
                yield return new TestCaseData(
                    1,
                    new Func<int, int>(x => x + 2),
                    new Func<int, int, int>((x, y) => x + y),
                    33,
                    1089);
                // 1 + 4 + 7 + 11 + ... 
                yield return new TestCaseData(
                    1,
                    new Func<int, int>(x => x + 3),
                    new Func<int, int, int>((x, y) => x + y),
                    22,
                    715);
                // 1 * 2 * 3 * ... * 5
                yield return new TestCaseData(
                    1,
                    new Func<int, int>(x => x + 1),
                    new Func<int, int, int>((x, y) => x * y),
                    5,
                    120);
                // 1 * 2 * 3 * ... * 10
                yield return new TestCaseData(
                    1,
                    new Func<int, int>(x => x + 1),
                    new Func<int, int, int>((x, y) => x * y),
                    10,
                    3628800);
            }
        }
        
        public static IEnumerable<TestCaseData> DataForCalculateTestForDoubles
        {
            get
            {
                yield return new TestCaseData(
                    1.1,
                    new Func<double, double>(x => x + 4.56),
                    new Func<double, double, double>((x, y) => x + y),
                    20,
                    888.4000000000001);
                yield return new TestCaseData(
                    100.121,
                    new Func<double, double>(x => x - 9.2),
                    new Func<double, double, double>((x, y) => x + y),
                    10,
                    587.2099999999999);
            }
        }
    }
}
