using CardDomain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestSnapDomain
{
    [TestClass]
    public class UnitTestCard
    {
        [TestMethod]
        public void TestCardConstruction()
        {
            var instance = new Card(0);
            Assert.IsNotNull(instance);
            Assert.AreEqual("Ace of Clubs", instance.ToString());
            Assert.AreEqual(1, instance.Rank);
            Assert.AreEqual(ESuit.Clubs, instance.Suit);
        }

        [TestMethod]
        public void TestCardToStringForSuitOfClubsWorks()
        {
            for (int i = 1; i <= 13; i++)
            {
                string expected = ExtractExpected(i);
                var instance = new Card(i - 1);
                Console.WriteLine(instance.ToString());
                Assert.IsNotNull(instance);
                Assert.AreEqual($"{expected} of Clubs", instance.ToString());
                Assert.AreEqual(i, instance.Rank);
            }
        }

        [TestMethod]
        public void TestCardToStringForSuitOfDiamondsWorks()
        {
            for (int i = 1; i <= 13; i++)
            {
                string expected = ExtractExpected(i);
                var instance = new Card(i - 1 + 13);
                Console.WriteLine(instance.ToString());
                Assert.IsNotNull(instance);
                Assert.AreEqual($"{expected} of Diamonds", instance.ToString());
                Assert.AreEqual(i, instance.Rank);
            }
        }

        [TestMethod]
        public void TestCardToStringForSuitOfHeartsWorks()
        {
            for (int i = 1; i <= 13; i++)
            {
                string expected = ExtractExpected(i);
                var instance = new Card(i - 1 + 26);
                Console.WriteLine(instance.ToString());
                Assert.IsNotNull(instance);
                Assert.AreEqual($"{expected} of Hearts", instance.ToString());
                Assert.AreEqual(i, instance.Rank);
            }
        }

        [TestMethod]
        public void TestCardToStringForSuitOfSpadesWorks()
        {
            for (int i = 1; i <= 13; i++)
            {
                string expected = ExtractExpected(i);
                var instance = new Card(i - 1 + 39);
                Console.WriteLine(instance.ToString());
                Assert.IsNotNull(instance);
                Assert.AreEqual($"{expected} of Spades", instance.ToString());
                Assert.AreEqual(i, instance.Rank);
            }
        }

        private static string ExtractExpected(int i)
        {
            var expected = i.ToString();
            switch (i)
            {
                case 1:
                    {
                        expected = "Ace";
                        break;
                    }
                case 11:
                    {
                        expected = "Jack";
                        break;
                    }
                case 12:
                    {
                        expected = "Queen";
                        break;
                    }
                case 13:
                    {
                        expected = "King";
                        break;
                    }
            }

            return expected;
        }
    }
}
