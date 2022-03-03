using CardDomain;
using DeckDomain;
using HandDomain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SnapDomain
{
    public class GamePlay
    {
        public Action<IEnumerable<Card>> RenderCards { get; set; } = (collection) => { };
        public Action<int> RenderSnap { get; set; } = (winner) => { };
        public Func<int> GetWinner { get; set; } = () => 0;
        public Action TurnDelay { get; set; } = () => { };

        DeckOfCards deck;
        HandOfCards player1Stack;
        HandOfCards player2Stack;
        HandOfCards player1Played;
        HandOfCards player2Played;
        Card [] lastPlayed = new Card[2] { null, null };
        /// <summary>
        /// PlayGame method...
        /// </summary>
        /// <returns>Winner - Player 1 or Player 2</returns>
        public int PlayGame()
        {
            // Init...
            deck = DeckOfCards.CreateDeck(1);
            deck.Shuffle();

            player1Stack = new HandOfCards();
            player1Played = new HandOfCards();
            player2Stack = new HandOfCards();
            player2Played = new HandOfCards();

            while (deck.NumberOfCards > 1)
            {
                deck.DealCardToHand(player1Stack);
                deck.DealCardToHand(player2Stack);
            }

            var turns = 0;
            var snapOccurred = false;
            while(true)
            {
                TurnDelay();

                switch(turns%2)
                {
                    case 0:
                    {
                        if (player1Stack.NumberOfCards == 0)
                        {
                            if (!snapOccurred) return 0;
                            return 2;   // Player 2 Winner
                        }
                        lastPlayed[0] = player1Stack.PlayACard();
                        player1Played.AddCard(lastPlayed[0]);
                        break;
                    }
                    case 1:
                    {
                        if (player2Stack.NumberOfCards == 0)
                        {
                            if (!snapOccurred) return 0;
                            return 1;   // Player 2 Winner
                        }
                        lastPlayed[1] = player2Stack.PlayACard();
                        player2Played.AddCard(lastPlayed[1]);
                        break;
                    }
                }
                turns++;

                bool isSnap = false;
                if (!lastPlayed.Any(x => x == null))
                {
                    isSnap = lastPlayed[0].EqualRank(lastPlayed[1]);
                    snapOccurred = true;
                }

                RenderCards(lastPlayed.Where(x => x != null));

                if (isSnap)
                {
                    int winner = GetWinner();
                    if (winner == 0)
                    {
                        var random = new Random((int)DateTime.Now.Ticks % 10000);
                        winner = random.Next(2) + 1;
                    }

                    // Winner
                    switch (winner)
                    {
                        case 1:
                        {
                            player1Stack.AddStack(player1Played);
                            player1Stack.AddStack(player2Played);
                            break;
                        }
                        case 2:
                        {
                            player2Stack.AddStack(player2Played);
                            player2Stack.AddStack(player1Played);
                            break;
                        }
                    }

                    RenderSnap(winner);

                    // Reset 
                    lastPlayed = new Card[2];
                }
            }
        }
    }
}
