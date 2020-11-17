using ExtendedDatabaseProblem;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestPersonId()
        {
            Person person = new Person(12, "Pesho");

            Assert.That(person.Id, Is.EqualTo(12));
        }

        [Test]
        public void TestPersonName()
        {
            Person person = new Person(12, "Pesho");

            Assert.That(person.UserName, Is.EqualTo("Pesho"));
        }

        [Test]
        public void Database_Constructor_EmptyCollection_ShoudReturnZero()
        {
            ExtendedDatabase data = new ExtendedDatabase();

            Assert.That(data.Count, Is.EqualTo(0));
        }

        [Test]
        public void Database_Constructor_CollectionWithTwoPersons_ShoudReturnTwo()
        {
            var personOne = new Person(1, "Pesho");
            var personTwo = new Person(2, "Gosho");
            ExtendedDatabase data = new ExtendedDatabase(personOne, personTwo);

            Assert.That(data.Count, Is.EqualTo(2));
        }

        [Test]
        public void Database_Constructor_CollectionWithSeventeenPerson_ShoudReturnExeption()
        {
            var personOne = new Person(1, "10");
            var personTwo = new Person(2, "20");
            var person3 = new Person(3, "30");
            var person4 = new Person(4, "40");
            var person5 = new Person(5, "50");
            var person6 = new Person(6, "60");
            var person7 = new Person(7, "70");
            var person8 = new Person(8, "80");
            var person9 = new Person(9, "90");
            var person10 = new Person(10, "100");
            var person11 = new Person(11, "110");
            var person12 = new Person(12, "120");
            var person13 = new Person(13, "130");
            var person14 = new Person(14, "140");
            var person15 = new Person(15, "150");
            var person16 = new Person(16, "160");
            var person17 = new Person(17, "170");

            Person[] persons = new Person[]
            {
                 personOne = new Person(1, "10"),
                 personTwo = new Person(2, "20"),
                 person3 = new Person(3, "30"),
                 person4 = new Person(4, "40"),
                 person5 = new Person(5, "50"),
                 person6 = new Person(6, "60"),
                 person7 = new Person(7, "70"),
                 person8 = new Person(8, "80"),
                 person9 = new Person(9, "90"),
                 person10 = new Person(10, "100"),
                 person11 = new Person(11, "110"),
                 person12 = new Person(12, "120"),
                 person13 = new Person(13, "130"),
                 person14 = new Person(14, "140"),
                 person15 = new Person(15, "150"),
                 person16 = new Person(16, "160"),
                 person17 = new Person(17, "170")
            };

            Assert.That(() => new ExtendedDatabase(persons), 
                Throws.ArgumentException.With.Message
                .EqualTo("Provided data length should be in range [0..16]!"));
        }

        [Test]
        public void Database_AddMethod_ShoudIncreaseCount()
        {
            ExtendedDatabase data = new ExtendedDatabase();

            var personOne = new Person(1, "Pesho");

            data.Add(personOne);

            Assert.That(data.Count, Is.EqualTo(1));
        }

        [Test]
        public void Database_AddMethod_AddingSeventeenElement_ShoudReturnExeption()
        {
            var personOne = new Person(1, "10");
            var personTwo = new Person(2, "20");
            var person3 = new Person(3, "30");
            var person4 = new Person(4, "40");
            var person5 = new Person(5, "50");
            var person6 = new Person(6, "60");
            var person7 = new Person(7, "70");
            var person8 = new Person(8, "80");
            var person9 = new Person(9, "90");
            var person10 = new Person(10, "100");
            var person11 = new Person(11, "110");
            var person12 = new Person(12, "120");
            var person13 = new Person(13, "130");
            var person14 = new Person(14, "140");
            var person15 = new Person(15, "150");
            var person16 = new Person(16, "160");
            var person17 = new Person(17, "170");

            Person[] persons = new Person[]
            {
                 personOne = new Person(1, "10"),
                 personTwo = new Person(2, "20"),
                 person3 = new Person(3, "30"),
                 person4 = new Person(4, "40"),
                 person5 = new Person(5, "50"),
                 person6 = new Person(6, "60"),
                 person7 = new Person(7, "70"),
                 person8 = new Person(8, "80"),
                 person9 = new Person(9, "90"),
                 person10 = new Person(10, "100"),
                 person11 = new Person(11, "110"),
                 person12 = new Person(12, "120"),
                 person13 = new Person(13, "130"),
                 person14 = new Person(14, "140"),
                 person15 = new Person(15, "150"),
                 person16 = new Person(16, "160")
            };

            ExtendedDatabase data = new ExtendedDatabase(persons);

            Assert.That(() => data.Add(person17),
                Throws.InvalidOperationException);
        }

        [Test]
        public void Database_AddMethod_AddingElementWithSameName_ShoudReturnExeption()
        {
            var personOne = new Person(1, "10");
            var personTwo = new Person(2, "20");
            var person3 = new Person(3, "20");
            

            Person[] persons = new Person[]
            {
                 personOne = new Person(1, "10"),
                 personTwo = new Person(2, "20"),
                 
            };

            ExtendedDatabase data = new ExtendedDatabase(persons);

            Assert.That(() => data.Add(person3),
                Throws.InvalidOperationException);
        }

        [Test]
        public void Database_AddMethod_AddingElementWithSameId_ShoudReturnExeption()
        {
            var personOne = new Person(1, "10");
            var personTwo = new Person(2, "20");
            var person3 = new Person(2, "30");


            Person[] persons = new Person[]
            {
                 personOne = new Person(1, "10"),
                 personTwo = new Person(2, "20"),

            };

            ExtendedDatabase data = new ExtendedDatabase(persons);

            Assert.That(() => data.Add(person3),
                Throws.InvalidOperationException);
        }

        [Test]
        public void Database_RemoveMethod_RemoveOneElement_ShoudDecreaseCount()
        {
            var personOne = new Person(1, "10");
            var personTwo = new Person(2, "20");

            Person[] persons = new Person[]
            {
                 personOne = new Person(1, "10"),
                 personTwo = new Person(2, "20"),

            };

            ExtendedDatabase data = new ExtendedDatabase(persons);
            data.Remove();

            Assert.That(data.Count, Is.EqualTo(1));
        }

        [Test]
        public void Database_RemoveMethod_RemoveOneElementFromEmptyCollection_ShoudReturnExeption()
        {

            ExtendedDatabase data = new ExtendedDatabase();

            Assert.That(() => data.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        public void Database_FindByName_EmptyName_ShoudReturnExeption()
        {
            var personOne = new Person(1, "10");
            var personTwo = new Person(2, "20");

            Person[] persons = new Person[]
            {
                 personOne = new Person(1, "10"),
                 personTwo = new Person(2, "20"),

            };
            ExtendedDatabase data = new ExtendedDatabase(persons);

            Assert.That(() => data.FindByUsername(""), Throws.ArgumentNullException);
        }

        [Test]
        public void Database_FindByName_WrongName_ShoudReturnExeption()
        {
            var personOne = new Person(1, "10");
            var personTwo = new Person(2, "20");

            Person[] persons = new Person[]
            {
                 personOne = new Person(1, "10"),
                 personTwo = new Person(2, "20"),

            };
            ExtendedDatabase data = new ExtendedDatabase(persons);

            Assert.That(() => data.FindByUsername("30"), Throws.InvalidOperationException);
        }

        [Test]
        public void Database_FindByName_ReturnsRightUser()
        {
            var personOne = new Person(1, "10");
            var personTwo = new Person(2, "20");

            Person[] persons = new Person[]
            {
                 personOne = new Person(1, "10"),
                 personTwo = new Person(2, "20"),

            };
            ExtendedDatabase data = new ExtendedDatabase(persons);

            Person newPerson = data.FindByUsername("10");

            Assert.That(personOne, Is.EqualTo(newPerson));
        }


        [Test]
        public void Database_FindById_NegativeId_ShoudReturnExeption()
        {

            ExtendedDatabase data = new ExtendedDatabase();

            Assert.Throws<ArgumentOutOfRangeException>(() => data.FindById(-1));
        }

        [Test]
        public void Database_FindById_WrongId_ShoudReturnExeption()
        {
            var personOne = new Person(1, "10");
            var personTwo = new Person(2, "20");

            Person[] persons = new Person[]
            {
                 personOne = new Person(1, "10"),
                 personTwo = new Person(2, "20"),

            };
            ExtendedDatabase data = new ExtendedDatabase(persons);

            Assert.Throws<InvalidOperationException>(() => data.FindById(3));
        }

        [Test]
        public void Database_FindByID_ReturnsRightUser()
        {
            var personOne = new Person(1, "10");
            var personTwo = new Person(2, "20");

            Person[] persons = new Person[]
            {
                 personOne = new Person(1, "10"),
                 personTwo = new Person(2, "20"),

            };
            ExtendedDatabase data = new ExtendedDatabase(persons);

            Person newPerson = data.FindById(1);

            Assert.That(personOne, Is.EqualTo(newPerson));
        }
    }
}