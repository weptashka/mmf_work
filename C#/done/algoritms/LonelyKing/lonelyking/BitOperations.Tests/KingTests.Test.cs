using NUnit.Framework;
using static BitOperationsTask.King;

namespace BitOperationsTask.Tests
{
    public class KingTests
    {
        [TestCase("1 5 1 5 2 7 2 8", ExpectedResult = 2)]
        [TestCase("1 3 6 5 2 7 2 8", ExpectedResult = 3)]
        [TestCase("5 5 7 7 2 2 2 8", ExpectedResult = 6)]
        [TestCase("2 3 4 1 3 2 5 6 8 2 1 7", ExpectedResult = 9)]
        public int InsertNumberIntoAnother_ReturnChangedNumber(string destinationNumber)
        => LonelyKing(destinationNumber);

        [Test]
        public void LonelyKing_IfStringIsEmpty_ThrowArgumentException() =>
           Assert.Throws<NotImplementedException>(() => LonelyKing(string.Empty), message: $"The king didn't budge");

        [Test]
        public void LonelyKing_IfNumbersMoreThanEight_ThrowArgumentException() =>
           Assert.Throws<NotImplementedException>(() => LonelyKing("2 3 4 1 3 2 5 6 8 2 1 7 9"), message: $"This direction does not exist.");

        [Test]
        public void LonelyKing_NeverStepTwoTimes_ThrowArgumentException() =>
           Assert.Throws<NotImplementedException>(() => LonelyKing("2 3 4 1 3 2 5 6"), message: $"The king did not step on the cells twice");
    }
}
