using DeckDomain;
using HandDomain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestSnapDomain
{
    [TestClass]
    public class UnitTestHandAndDeck
    {
        [TestMethod]
        public void TestDeckConstruction()
        {
            var instance = DeckOfCards.CreateDeck(1);
            Assert.IsNotNull(instance);
            Assert.AreEqual("52 Cards", instance.ToString());
            Assert.AreEqual(52, instance.NumberOfCards);
        }

        [TestMethod]
        public void TestHandConstruction()
        {
            var instance = new HandOfCards();
            Assert.IsNotNull(instance);
            Assert.AreEqual("0 Cards", instance.ToString());
            Assert.AreEqual(0, instance.NumberOfCards);
        }

        public void TestDealing()
        {
            var deck = DeckOfCards.CreateDeck(1);
            Assert.IsNotNull(deck);
            Assert.AreEqual("52 Cards", deck.ToString());
            Assert.AreEqual(52, deck.NumberOfCards);
            var hand = new HandOfCards();
            Assert.IsNotNull(hand);
            Assert.AreEqual("0 Cards", hand.ToString());
            Assert.AreEqual(0, hand.NumberOfCards);

            var expectedDeck = 51;
            var expectedHand = 1;

            while (deck.NumberOfCards > 0)
            {
                deck.DealCardToHand(hand);
                Assert.AreEqual(expectedDeck, deck.NumberOfCards);
                Assert.AreEqual(expectedHand, hand.NumberOfCards);
                expectedDeck--;
                expectedHand++;
            }
        }
    }
}
