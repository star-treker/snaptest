using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDomain
{
    /// <summary>
    /// Enum for Card Suit
    /// </summary>
    public enum ESuit
    {
        Clubs    = 1,
        Diamonds = 2,
        Hearts   = 3,
        Spades   = 4
    }

    /// <summary>
    /// Class representing a Card
    /// </summary>
    public class Card : IRankable
    {
        public ESuit Suit { get; }

        public int Rank { get; }

        internal Card(int rank, ESuit suit)
        {
            if (rank < 1 || rank > 13) throw new ArgumentOutOfRangeException();
            Rank = rank;
        }

        internal Card(int zeroBasedRank)
        {
            if (zeroBasedRank < 0) throw new ArgumentOutOfRangeException();
            Rank = (zeroBasedRank % 13) + 1;
            int suit = (zeroBasedRank / 13) % 4;
            Suit = (ESuit)(suit + 1);
        }

        public override string ToString()
        {
            switch(Rank)
            {
                case 1:
                    return $"Ace of {Suit}";
                case 11:
                    return $"Jack of {Suit}";
                case 12:
                    return $"Queen of {Suit}";
                case 13:
                    return $"King of {Suit}";
                default:
                    return $"{Rank} of {Suit}";
            }
        }

        public bool EqualRank(IRankable target)
        {
            if (target == null) throw new ArgumentNullException();
            return Rank == target.Rank;
        }
    }

    public interface IRankable
    {
        int Rank { get; }
        bool EqualRank(IRankable target);
    }
}
