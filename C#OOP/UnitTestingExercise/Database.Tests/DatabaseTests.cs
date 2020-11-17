using NUnit.Framework;
using DatabaseProblem;

namespace Tests
{
    [TestFixture]
    public class DatabaseTests
    {

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ContructorWithEmptyCollectionShoudReturnZero()
        {
            Database data = new Database();
            Assert.That(data.Count, Is.EqualTo(0));
        }

        [Test]
        public void ConstructorWithTwoIntigersShoudReturnTwo()
        {
            Database data = new Database(1, 2);

            Assert.That(data.Count, Is.EqualTo(2));
        }

        [Test]
        public void ConstructorWithTwoIntigersShoudReturnSameOrder()
        {
            Database data = new Database(1, 2);

            int[] actualResult = data.Fetch();
            int[] expectedResult = { 1, 2 };

            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }

        [Test]
        public void ConstructorWithSeventeenElementShoudReturnExeption()
        {
            int[] numbers = new int[17];

            Assert.That(() => new Database(numbers), Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }


        [Test]
        public void AddMethodWithOneElement()
        {
            Database data = new Database(1, 2);
            data.Add(3);

            int[] actualResult = data.Fetch();
            int[] expectedResult = { 1, 2, 3 };

            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }

        [Test]
        public void AddMethodWithSeventeenElementShoudReturnExeption()
        {
            int[] numbers = new int[16];
            Database data = new Database(numbers);

            Assert.That(() => data.Add(0), Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void AddMethodShoudIncreaseCount()
        {
            Database data = new Database();
            data.Add(1);

            Assert.That(data.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddMethodShoudReturnSameOrder()
        {
            Database data = new Database();
            data.Add(1);
            data.Add(2);
            int[] expectedResult = { 1, 2 };
            Assert.That(data.Fetch(), Is.EqualTo(expectedResult));
        }

        [Test]
        public void RemoveMethodShoudRemoveCount()
        {
            Database data = new Database(1, 2);
            data.Remove();

            Assert.That(data.Count, Is.EqualTo(1));
        }

        [Test]
        public void RemoveMethodEmptyCollectionShoudThrowExeption()
        {
            Database data = new Database();

            Assert.That(data.Remove, Throws.InvalidOperationException);
        }
    }
}