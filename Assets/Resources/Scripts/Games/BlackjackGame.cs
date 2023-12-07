using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BlackjackGame
{
    Deck deck;
    private List<Player> players;
    public List<Card> dealerHand;

    public BlackjackGame()
    {
        players = new()
        { new Player()};
        dealerHand = new();
        deck = new();
    }

    public BlackjackGame(List<Player> players)
    {
        this.players = players;
        dealerHand = new();
        deck = new();
    }

    public void ShuffleDeck()
    {
        deck.Shuffle();
    }

    private int GetCardValue(Card card)
    {
        int value;

        if (card.rank == 1)
        {
            value = 11;
        }
        else if (card.rank == 11 || card.rank == 12 || card.rank == 13)
        {
            value = 10;
        }
        else
        {
            value = card.rank;
        }

        return value;
    }

    public void DealInitialHands()
    {
        ShuffleDeck();

        dealerHand.Clear();
        dealerHand.Add(DrawCard());
        dealerHand.Add(DrawCard());

        foreach (Player player in players)
        {
            player.hand.Clear();
            player.hand.Add(DrawCard());
            player.hand.Add(DrawCard());
        }
    }

    public Card DrawCard()
    {
        Card drawnCard = deck.DrawCard();
        return drawnCard;
    }

    public void PlayerHit(Player player)
    {
        Card card = DrawCard();
        Debug.Log(card.ToString());

        player.hand.Add(card);
    }

    public int CalculateHandValue(List<Card> hand)
    {
        int value = 0;
        int numAces = 0;

        foreach (Card card in hand)
        {
            int cardValue = GetCardValue(card);
            value += cardValue;

            if (cardValue == 11)
            {
                numAces++;
            }

            while (value > 21 && numAces > 0)
            {
                value -= 10;
                numAces--;
            }
        }

        return value;
    }

    public bool PlayerBusted(Player player)
    {
        return CalculateHandValue(player.hand) > 21;
    }

    public void DealerPlay()
    {
        while (CalculateHandValue(dealerHand) < 17)
        {
            dealerHand.Add(DrawCard());
        }
    }

    public bool DealerBusted()
    {
        return CalculateHandValue(dealerHand) > 21;
    }

    public bool PlayerWins(Player player)
    {
        if (PlayerBusted(player) || (!DealerBusted() && CalculateHandValue(player.hand) <= CalculateHandValue(dealerHand))) return false;

        /*foreach (Player otherPlayer in players)
        {
            if (PlayerBusted(otherPlayer) || otherPlayer.Equals(player)) break;

            if (CalculateHandValue(otherPlayer.hand) > CalculateHandValue(player.hand)) return false;
        }*/

        return true;
    }

    public bool DealerWins(Player player)
    {
        return !DealerBusted() && (PlayerBusted(player) || CalculateHandValue(dealerHand) >= CalculateHandValue(player.hand));
    }

    [System.Serializable]
    public class Player
    {
        public string playerName;
        public List<Card> hand;

        public void InitializePlayer(string name)
        {
            playerName = name;
            this.hand = new List<Card>();
        }

        public Player(string name)
        {
            this.playerName = name;
            this.hand = new();
        }

        public Player()
        {
            playerName = "player";
            this.hand = new();
        }
    }

    [System.Serializable]
    public class Deck
    {
        public List<Card> cards = new();

        public Deck()
        {
            InitializeDeck();
        }

        public void InitializeDeck()
        {
            CardAssembler.Suits[] suits = new CardAssembler.Suits[] { CardAssembler.Suits.heart, CardAssembler.Suits.diamond, CardAssembler.Suits.club, CardAssembler.Suits.spade };
            int[] ranks = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };

            foreach (CardAssembler.Suits suit in suits)
            {
                foreach (int rank in ranks)
                {
                    Card card = new(suit, rank);
                    cards.Add(card);
                }
            }
        }

        public void Shuffle()
        {
            for (int i = 0; i < cards.Count; i++)
            {
                Card temp = cards[i];
                int randomIndex = UnityEngine.Random.Range(i, cards.Count);
                cards[i] = cards[randomIndex];
                cards[randomIndex] = temp;
            }
        }

        public Card DrawCard()
        {
            if (cards.Count > 0)
            {
                Card drawnCard = cards[0];
                cards.RemoveAt(0);
                return drawnCard;
            }

            Debug.LogError("No cards left in the deck!");
            return null;
            
        }
    }

    [System.Serializable]
    public class Card
    {
        public CardAssembler.Suits suit;
        public int rank;

        public Card(CardAssembler.Suits suit, int rank)
        {
            this.suit = suit;
            this.rank = rank;
        }

        public override string ToString()
        {
            return rank.ToString() + " of " + Enum.GetName(typeof(CardAssembler.Suits), suit);
        }
    }
}
