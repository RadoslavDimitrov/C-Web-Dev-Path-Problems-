namespace Computers.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    public class ComputerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor_SetCorrectNameProperty()
        {
            Computer comp = new Computer("a");

            Assert.AreEqual("a", comp.Name);
        }

        [Test]
        public void Constructor_PartsCollectionIsEmpty()
        {
            Computer comp = new Computer("a");

            Assert.IsEmpty(comp.Parts);
        }


        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void NameProperty_EmptyValue_ShouldThrowArgumenException(string name)
        {
            Assert.Throws<ArgumentNullException>(() => new Computer(name));
        }

        [Test]
        public void PartsProperty_AddTwoParts_ShoudIncreaseCount()
        {
            Computer comp = new Computer("a");

            comp.AddPart(new Part("b", 12));
            comp.AddPart(new Part("c", 10));

            Assert.AreEqual(2, comp.Parts.Count);
        }

        [Test]
        public void TotalPrice_ShoudReturnCorrectResult()
        {
            Computer comp = new Computer("a");

            comp.AddPart(new Part("b", 1));
            comp.AddPart(new Part("a", 2));
            comp.AddPart(new Part("c", 3));

            Assert.AreEqual(6, comp.TotalPrice);
        }

        [Test]
        public void AddPart_Null_ShoudThrowInvalidOperationException()
        {
            Computer comp = new Computer("a");

            Assert.Throws<InvalidOperationException>(() => comp.AddPart(null));
        }

        [Test]
        public void AddPart_OnePart_ShoudIncreaseCount()
        {
            Computer comp = new Computer("a");

            comp.AddPart(new Part("a", 1));

            Assert.AreEqual(1, comp.Parts.Count);
        }

        [Test]
        public void AddPart_OnePart_ShouldAddCorrectPart()
        {
            Computer comp = new Computer("a");

            comp.AddPart(new Part("a", 1));

            Part actualPart = comp.Parts.FirstOrDefault(p => p.Name == "a");

            Assert.IsNotNull(actualPart);
        }

        [Test]
        public void RemovePart_ValidPart_ShoudRemoveSuccsesfully()
        {
            Computer comp = new Computer("a");

            Part part = new Part("a", 1);
            comp.AddPart(part);

            comp.RemovePart(part);

            Assert.AreEqual(0, comp.Parts.Count);
        }

        [Test]
        public void RemovePart_ValidPart_ShoudReturnTrue()
        {
            Computer comp = new Computer("a");

            Part part = new Part("a", 1);
            comp.AddPart(part);

            bool actualRes = comp.RemovePart(part);


            Assert.IsTrue(actualRes);
        }

        [Test]
        public void RemovePart_InalidPart_ShoudReturnFalse()
        {
            Computer comp = new Computer("a");

            Part part = new Part("a", 1);
            Part partTwo = new Part("b", 2);
            comp.AddPart(part);

            bool actualRes = comp.RemovePart(partTwo);


            Assert.IsFalse(actualRes);
        }

        [Test]
        public void RemovePart_ValidPart_ShoudReturnCorrectPart()
        {
            Computer comp = new Computer("a");

            Part part = new Part("a", 1);
            Part partTwo = new Part("b", 2);
            comp.AddPart(part);
            comp.RemovePart(part);

            Part actualPart = comp.Parts.FirstOrDefault(p => p.Name == "a");


            Assert.IsNull(actualPart);
        }

        [Test]
        public void GetPart_ValidPart_ShoudReturnCorrectPart()
        {
            Computer comp = new Computer("a");

            Part part = new Part("a", 1);

            comp.AddPart(part);


            Part actualPart = comp.GetPart("a");


            Assert.AreEqual("a", actualPart.Name);
        }


        [Test]
        public void GetPart_InvalidPart_ShoudReturnNull()
        {
            Computer comp = new Computer("a");

            Part part = new Part("a", 1);

            comp.AddPart(part);


            Part actualPart = comp.GetPart("b");


            Assert.IsNull(actualPart);
        }
    }
}