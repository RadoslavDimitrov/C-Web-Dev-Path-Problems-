using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        [SetUp]
        public void Setup()
        {
        }

        //[Test]
        //public void Constructor_ShoudInitializeCollectionWithEmptyValues()
        //{
        //    BankVault bv = new BankVault();

        //    bv.
        //}

        [Test]
        public void PuttingItemOnInvalidCell_ShoudThrowException()
        {
            BankVault bv = new BankVault();
            Item item = new Item("Pesho", "10");
            Assert.Throws<ArgumentException>(() => bv.AddItem("D2", item));
        }

        [Test]
        public void PuttingItemOnTakenCell_ShoudThrowException()
        {
            BankVault bv = new BankVault();
            Item item = new Item("Pesho", "10");
            bv.AddItem("A1", item);
            Item item2 = new Item("Gosho", "20");
            Assert.Throws<ArgumentException>(() => bv.AddItem("A1", item2));
        }

        [Test]
        public void TryAddOnAnotherCell_ShoudThrowException()
        {
            BankVault bv = new BankVault();
            Item item = new Item("Pesho", "10");
            bv.AddItem("A1", item);

            Assert.Throws<InvalidOperationException>(() => bv.AddItem("B1", item));
        }

        [Test]
        public void SucssecAdd_ShoudReturnExpectedMessage()
        {
            BankVault bv = new BankVault();
            Item item = new Item("Pesho", "10");
            string actual = bv.AddItem("A1", item);
            string excepted = $"Item:{item.ItemId} saved successfully!";

            Assert.AreEqual(excepted, actual);
        }

        [Test]
        public void SucssecRemove_ShoudReturnExpectedMessage()
        {
            BankVault bv = new BankVault();
            Item item = new Item("Pesho", "10");
            bv.AddItem("A1", item);
            string actual = bv.RemoveItem("A1", item);
            string expected = $"Remove item:{item.ItemId} successfully!";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Remove_WrongCell_ShoudThrowException()
        {
            BankVault bv = new BankVault();
            Item item = new Item("Pesho", "10");
            bv.AddItem("A1", item);

            Assert.Throws<ArgumentException>(() => bv.RemoveItem("A2", item));
        }

        [Test]
        public void Remove_NotExistingCell_ShoudThrowException()
        {
            BankVault bv = new BankVault();
            Item item = new Item("Pesho", "10");
            bv.AddItem("A1", item);

            Assert.Throws<ArgumentException>(() => bv.RemoveItem("F2", item));
        }
    }
}