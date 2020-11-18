//using FightingArena;
using NUnit.Framework;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor_RightName_ShoudReturnName()
        {
            Warrior warrior = new Warrior("morve", 10, 100);

            Assert.That(warrior.Name, Is.EqualTo("morve"));
        }

        [Test]
        public void Constructor_PositiveDmg_ShoudReturnDmg()
        {
            Warrior warrior = new Warrior("morve", 10, 100);

            Assert.That(warrior.Damage, Is.EqualTo(10));
        }

        [Test]
        public void Constructor_PositiveHp_ShoudReturnHp()
        {
            Warrior warrior = new Warrior("morve", 10, 100);

            Assert.That(warrior.HP, Is.EqualTo(100));
        }

        [Test]
        public void Constructor_NullName_ShoudReturnException()
        {
            Assert.That(() => new Warrior(null, 10, 100), Throws.ArgumentException);
        }

        [Test]
        public void Constructor_WhiteSpaceName_ShoudReturnException()
        {
            Assert.That(() => new Warrior(" ", 10, 100), Throws.ArgumentException);
        }

        [Test]
        public void Constructor_EmptyName_ShoudReturnException()
        {
            Assert.That(() => new Warrior("", 10, 100), Throws.ArgumentException);
        }

        [Test]
        public void Constructor_NegativeDmg_ShoudReturnException()
        {
            Assert.That(() => new Warrior("morve", -10, 100), Throws.ArgumentException);
        }

        [Test]
        public void Constructor_ZeroDmg_ShoudReturnException()
        {
            Assert.That(() => new Warrior("morve", 0, 100), Throws.ArgumentException);
        }

        [Test]
        public void Constructor_NegativeHp_ShoudReturnException()
        {
            Assert.That(() => new Warrior("morve", 10, -100), Throws.ArgumentException);
        }

        [Test]
        public void AttackMethod_ThisHpLowerThanMin_ShoudReturnException()
        {
            Warrior warrior = new Warrior("morve", 10, 20);
            Warrior secondWarrior = new Warrior("morve", 10, 100);

            Assert.That(() => warrior.Attack(secondWarrior), Throws.InvalidOperationException);
        }

        [Test]
        public void AttackMethod_ThisHpEqualThanMin_ShoudReturnException()
        {
            Warrior warrior = new Warrior("morve", 10, 30);
            Warrior secondWarrior = new Warrior("morve", 10, 100);

            Assert.That(() => warrior.Attack(secondWarrior), Throws.InvalidOperationException);
        }

        [Test]
        public void AttackMethod_OtherHpEqualThanMin_ShoudReturnException()
        {
            Warrior warrior = new Warrior("morve", 10, 100);
            Warrior secondWarrior = new Warrior("morve", 10, 30);

            Assert.That(() => warrior.Attack(secondWarrior), Throws.InvalidOperationException);
        }

        [Test]
        public void AttackMethod_OtherHpLowerThanMin_ShoudReturnException()
        {
            Warrior warrior = new Warrior("morve", 10, 100);
            Warrior secondWarrior = new Warrior("morve", 10, 20);

            Assert.That(() => warrior.Attack(secondWarrior), Throws.InvalidOperationException);
        }

        [Test]
        public void AttackMethod_ThisHpLowerThanOtherAttack_ShoudReturnException()
        {
            Warrior warrior = new Warrior("morve", 10, 40);
            Warrior secondWarrior = new Warrior("morve", 50, 100);

            Assert.That(() => warrior.Attack(secondWarrior), Throws.InvalidOperationException);
        }

        [Test]
        public void AttackMethod_ShoudReturnLoweredHp()
        {
            Warrior warrior = new Warrior("morve",50, 100);
            Warrior secondWarrior = new Warrior("morve", 10, 100);

            warrior.Attack(secondWarrior);

            Assert.That(warrior.HP, Is.EqualTo(90));
        }

        [Test]
        public void AttackMethod_ThisDmgGreaterThanOtherHp_ShoudReturnOtherHpZero()
        {
            Warrior warrior = new Warrior("morve", 50, 100);
            Warrior secondWarrior = new Warrior("morve", 10,40);

            warrior.Attack(secondWarrior);

            Assert.That(secondWarrior.HP, Is.EqualTo(0));
        }

        [Test]
        public void AttackMethod_ShoudReturnOtherHpLowered()
        {
            Warrior warrior = new Warrior("morve", 50, 100);
            Warrior secondWarrior = new Warrior("morve", 10, 100);

            warrior.Attack(secondWarrior);

            Assert.That(secondWarrior.HP, Is.EqualTo(50));
        }
    }
}