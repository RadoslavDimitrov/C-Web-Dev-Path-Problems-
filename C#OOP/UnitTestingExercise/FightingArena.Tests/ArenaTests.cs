//using FightingArena;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{

    public class ArenaTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor_EmptyCollection_ShoudReturnCount()
        {
            Arena arena = new Arena();

            Assert.That(arena.Count, Is.EqualTo(0));
        }

        [Test]
        public void Constructor_ShoudReturnSameCollection()
        {
            Warrior warrior = new Warrior("morve", 10, 100);
            Warrior warriorTwo = new Warrior("hagar", 10, 100);
            Arena arena = new Arena();
            arena.Enroll(warrior);
            arena.Enroll(warriorTwo);

            var expectedCollection = new List<Warrior>()
            {
                warrior,
                warriorTwo 
            };
            var actualCollection = arena.Warriors;

            Assert.AreEqual(expectedCollection, actualCollection);
        }

        [Test]
        public void Constructor_TwoElementsCollection_ShoudReturnCount()
        {
            Warrior warrior = new Warrior("morve", 10, 100);
            Warrior warriorTwo = new Warrior("hagar", 10, 100);
            Arena arena = new Arena();
            arena.Enroll(warrior);
            arena.Enroll(warriorTwo);

            Assert.That(arena.Count, Is.EqualTo(2));
        }

        [Test]
        public void EnrollMethod_TwoWarriorsSameName_ShoudReturnException()
        {
            Warrior warrior = new Warrior("morve", 10, 100);
            Warrior warriorTwo = new Warrior("morve", 10, 100);
            Arena arena = new Arena();
            arena.Enroll(warrior);
            Assert.That(() => arena.Enroll(warriorTwo), Throws.InvalidOperationException);
        }

        [Test]
        public void FightMethod_AttackerNull_ShoudReturnException()
        {
            Warrior warrior = new Warrior("morve", 10, 100);

            Arena arena = new Arena();
            arena.Enroll(warrior);

            Assert.That(() => arena.Fight(null, "morve"), Throws.InvalidOperationException);
        }

        [Test]
        public void FightMethod_DefenderNull_ShoudReturnException()
        {
            Warrior warrior = new Warrior("morve", 10, 100);

            Arena arena = new Arena();
            arena.Enroll(warrior);

            Assert.That(() => arena.Fight("morve", null), Throws.InvalidOperationException);
        }

        [Test]
        public void CheckIfAttackWorksProperly()
        {
            Warrior warrior = new Warrior("morve", 10, 100);
            Warrior warriorTwo = new Warrior("hagar", 10, 100);
            Arena arena = new Arena();
            arena.Enroll(warrior);
            arena.Enroll(warriorTwo);

            var attacker = arena.Warriors.First(w => w.Name == "morve");
            var defender = arena.Warriors.First(w => w.Name == "hagar");

            var expectedHp = defender.HP - attacker.Damage;

            if (expectedHp < 0)
            {
                expectedHp = 0;
            }

            arena.Fight("morve", "hagar");

            var actualHp = defender.HP;

            Assert.AreEqual(expectedHp, actualHp);

        }
    }
}
