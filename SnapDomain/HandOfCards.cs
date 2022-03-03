using CardDomain;
using System;
using System.Collections.Generic;

namespace HandDomain
{
    public class HandOfCards
    {
        public List<Card> cards;

        public HandOfCards()
        {
            cards = new List<Card>();
        }

        public void AddCard(Card card)
        {
            cards.Add(card);
        }

        public int NumberOfCards => cards.Count;

        public override string ToString()
        {
            return $"{NumberOfCards} Cards";
        }

        public Card PlayACard()
        {
            if (cards.Count < 1) throw new InvalidOperationException();
            int top = cards.Count - 1;
            var card = cards[top];
            cards.RemoveAt(top);
            return card;
        }

        public void AddStack(HandOfCards stack)
        {
            this.cards.AddRange(stack.cards);
            stack.cards.Clear();
        }
    }
}
