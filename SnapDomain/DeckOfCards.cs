using CardDomain;
using HandDomain;
using System;
using System.Collections.Generic;

namespace DeckDomain
{
    public class DeckOfCards : HandOfCards
    {
        private DeckOfCards(int totalCards)
        {
            cards = new List<Card>(totalCards);
            for (int i = 0; i < totalCards; i++)
            {
                cards.Add(new Card(i));
            }
        }

        public static DeckOfCards CreateDeck(int numberOfDecks = 1)
        {
            if (numberOfDecks <= 0) throw new ArgumentOutOfRangeException();
            int totalCards = numberOfDecks * 52;
            var desk = new DeckOfCards(totalCards);
            return desk;
        }

        public void Shuffle()
        {
            var random = new Random();
            var times = cards.Count * 2;   // Keep value integer...
            while(--times > 0)
            {
                int position = random.Next(cards.Count);
                var randomCard = cards[position];
                cards.RemoveAt(position);
                cards.Add(randomCard);
            }
        }

        public void DealCardToHand(HandOfCards handOfCards)
        {
            handOfCards.AddCard(PlayACard());
        }
    }
}
