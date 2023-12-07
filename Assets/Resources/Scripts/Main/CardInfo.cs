using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInfo : MonoBehaviour
{
    [SerializeField] private int value;
    [SerializeField] private Suits suit = Suits.heart;
    [SerializeField] private CardTypes cardType;

    private Sprite[] suitSprites, numberSprites, redNumberSprites, letterSprites, redLetterSprites, figureSprites, redFigureSprites;

    private void Awake()
    {
        suitSprites = Resources.LoadAll<Sprite>("Sprites/heart-diamond-spade-club");
        numberSprites = Resources.LoadAll<Sprite>("Sprites/numbers");
        redNumberSprites = Resources.LoadAll<Sprite>("Sprites/red-numbers");
        letterSprites = Resources.LoadAll<Sprite>("Sprites/letters");
        redLetterSprites = Resources.LoadAll<Sprite>("Sprites/red-letters");
        figureSprites = Resources.LoadAll<Sprite>("Sprites/figures");
        redFigureSprites = Resources.LoadAll<Sprite>("Sprites/red-figures");
    }

    private void Start()
    {
        SetCardType();
        if (cardType == CardTypes._default) CreateDefaultCard();
        else if (cardType == CardTypes.ace) CreateAceCard();
        else if (cardType == CardTypes.jack) CreateJackCard();
        else if (cardType == CardTypes.queen) CreateQueenCard();
        else if (cardType == CardTypes.king) CreateKingCard();
    }

    private void CreateDefaultCard()
    {
        CreateComponent("Background", Resources.Load<Sprite>("Sprites/base-card"), Vector3.zero, 0);

        CreateComponent("Suit", suitSprites[(int)this.suit], GetPositionFromPixelSize(new(5, 5), new(5, 5), new(64, 96), 16));

        CreateComponent("FirstNumber", ((this.suit == Suits.diamond || this.suit == Suits.heart) ? redNumberSprites : numberSprites)[value > 9 ? (value - (value % 10)) / 10 : value % 10], GetPositionFromPixelSize(new(11, 5), new(5, 5), new(64, 96), 16));

        CreateComponent("SecondNumber", value > 9 ? ((this.suit == Suits.diamond || this.suit == Suits.heart) ? redNumberSprites : numberSprites)[value % 10] : null, GetPositionFromPixelSize(new(16, 5), new(5, 5), new(64, 96), 16));

        CreateInvertedComponent("InvertedSuit", suitSprites[(int)this.suit], GetPositionFromPixelSize(new(59, 91), new(-5, -5), new(64, 96), 16));

        CreateInvertedComponent("InvertedFirstNumber", ((this.suit == Suits.diamond || this.suit == Suits.heart) ? redNumberSprites : numberSprites)[value > 9 ? (value - (value % 10)) / 10 : value % 10], GetPositionFromPixelSize(new(53, 91), new(-5, -5), new(64, 96), 16));

        CreateInvertedComponent("InvertedSecondNumber", value > 9 ? ((this.suit == Suits.diamond || this.suit == Suits.heart) ? redNumberSprites : numberSprites)[value % 10] : null, GetPositionFromPixelSize(new(48, 91), new(-5, -5), new(64, 96), 16));

        
    }

    private void CreateAceCard()
    {
        GameObject background = new("Background");
        background.transform.parent = this.transform;
        background.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
        background.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/base-card");

        GameObject suit = new("Suit");
        suit.transform.parent = this.transform;
        suit.transform.SetLocalPositionAndRotation(GetPositionFromPixelSize(new(5, 5), new(5, 5), new(64, 96), 16), Quaternion.identity);
        SpriteRenderer suitSP = suit.AddComponent<SpriteRenderer>();
        suitSP.sprite = suitSprites[(int)this.suit];
        suitSP.sortingOrder = 1;

        GameObject firstNumber = new("Letter");
        firstNumber.transform.parent = this.transform;
        firstNumber.transform.SetLocalPositionAndRotation(GetPositionFromPixelSize(new(11, 5), new(5, 5), new(64, 96), 16), Quaternion.identity);
        SpriteRenderer firstNumberSP = firstNumber.AddComponent<SpriteRenderer>();
        firstNumberSP.sprite = ((this.suit == Suits.diamond || this.suit == Suits.heart) ? redLetterSprites : letterSprites)[0];
        firstNumberSP.sortingOrder = 1;

        GameObject insuit = new("InvertedSuit");
        insuit.transform.parent = this.transform;
        insuit.transform.SetLocalPositionAndRotation(GetPositionFromPixelSize(new(59, 91), new(-5, -5), new(64, 96), 16), Quaternion.Euler(0, 0, 180));
        SpriteRenderer insuitSP = insuit.AddComponent<SpriteRenderer>();
        insuitSP.sprite = suitSprites[(int)this.suit];
        insuitSP.sortingOrder = 1;

        GameObject infirstNumber = new("InvertedLetter");
        infirstNumber.transform.parent = this.transform;
        infirstNumber.transform.SetLocalPositionAndRotation(GetPositionFromPixelSize(new(53, 91), new(-5, -5), new(64, 96), 16), Quaternion.Euler(0, 0, 180));
        SpriteRenderer infirstNumberSP = infirstNumber.AddComponent<SpriteRenderer>();
        infirstNumberSP.sprite = ((this.suit == Suits.diamond || this.suit == Suits.heart) ? redLetterSprites : letterSprites)[0];
        infirstNumberSP.sortingOrder = 1;

        GameObject ace = new("Ace");
        ace.transform.parent = this.transform;
        ace.transform.SetLocalPositionAndRotation(new(), new());
        ace.transform.localScale = Vector3.one * 5;
        SpriteRenderer aceSP = ace.AddComponent<SpriteRenderer>();
        aceSP.sprite = suitSprites[(int)this.suit];
        aceSP.sortingOrder = 1;
    }

    private void CreateJackCard()
    {
        GameObject background = new("Background");
        background.transform.parent = this.transform;
        background.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
        background.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/base-card");

        GameObject suit = new("Suit");
        suit.transform.parent = this.transform;
        suit.transform.SetLocalPositionAndRotation(GetPositionFromPixelSize(new(5, 5), new(5, 5), new(64, 96), 16), Quaternion.identity);
        SpriteRenderer suitSP = suit.AddComponent<SpriteRenderer>();
        suitSP.sprite = suitSprites[(int)this.suit];
        suitSP.sortingOrder = 1;

        GameObject firstNumber = new("Letter");
        firstNumber.transform.parent = this.transform;
        firstNumber.transform.SetLocalPositionAndRotation(GetPositionFromPixelSize(new(11, 5), new(5, 5), new(64, 96), 16), Quaternion.identity);
        SpriteRenderer firstNumberSP = firstNumber.AddComponent<SpriteRenderer>();
        firstNumberSP.sprite = ((this.suit == Suits.diamond || this.suit == Suits.heart) ? redLetterSprites : letterSprites)[1];
        firstNumberSP.sortingOrder = 1;

        GameObject insuit = new("InvertedSuit");
        insuit.transform.parent = this.transform;
        insuit.transform.SetLocalPositionAndRotation(GetPositionFromPixelSize(new(59, 91), new(-5, -5), new(64, 96), 16), Quaternion.Euler(0, 0, 180));
        SpriteRenderer insuitSP = insuit.AddComponent<SpriteRenderer>();
        insuitSP.sprite = suitSprites[(int)this.suit];
        insuitSP.sortingOrder = 1;

        GameObject infirstNumber = new("InvertedLetter");
        infirstNumber.transform.parent = this.transform;
        infirstNumber.transform.SetLocalPositionAndRotation(GetPositionFromPixelSize(new(53, 91), new(-5, -5), new(64, 96), 16), Quaternion.Euler(0, 0, 180));
        SpriteRenderer infirstNumberSP = infirstNumber.AddComponent<SpriteRenderer>();
        infirstNumberSP.sprite = ((this.suit == Suits.diamond || this.suit == Suits.heart) ? redLetterSprites : letterSprites)[1];
        infirstNumberSP.sortingOrder = 1;

        GameObject jack = new("Jack");
        jack.transform.parent = this.transform;
        jack.transform.SetLocalPositionAndRotation(new(), new());
        jack.transform.localScale = Vector3.one;
        SpriteRenderer jackSP = jack.AddComponent<SpriteRenderer>();
        jackSP.sprite = ((this.suit == Suits.diamond || this.suit == Suits.heart) ? redFigureSprites : figureSprites)[0];
        jackSP.sortingOrder = 1;
    }

    private void CreateQueenCard()
    {
        GameObject background = new("Background");
        background.transform.parent = this.transform;
        background.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
        background.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/base-card");

        GameObject suit = new("Suit");
        suit.transform.parent = this.transform;
        suit.transform.SetLocalPositionAndRotation(GetPositionFromPixelSize(new(5, 5), new(5, 5), new(64, 96), 16), Quaternion.identity);
        SpriteRenderer suitSP = suit.AddComponent<SpriteRenderer>();
        suitSP.sprite = suitSprites[(int)this.suit];
        suitSP.sortingOrder = 1;

        GameObject firstNumber = new("Letter");
        firstNumber.transform.parent = this.transform;
        firstNumber.transform.SetLocalPositionAndRotation(GetPositionFromPixelSize(new(11, 5), new(5, 5), new(64, 96), 16), Quaternion.identity);
        SpriteRenderer firstNumberSP = firstNumber.AddComponent<SpriteRenderer>();
        firstNumberSP.sprite = ((this.suit == Suits.diamond || this.suit == Suits.heart) ? redLetterSprites : letterSprites)[3];
        firstNumberSP.sortingOrder = 1;

        GameObject insuit = new("InvertedSuit");
        insuit.transform.parent = this.transform;
        insuit.transform.SetLocalPositionAndRotation(GetPositionFromPixelSize(new(59, 91), new(-5, -5), new(64, 96), 16), Quaternion.Euler(0, 0, 180));
        SpriteRenderer insuitSP = insuit.AddComponent<SpriteRenderer>();
        insuitSP.sprite = suitSprites[(int)this.suit];
        insuitSP.sortingOrder = 1;

        GameObject infirstNumber = new("InvertedLetter");
        infirstNumber.transform.parent = this.transform;
        infirstNumber.transform.SetLocalPositionAndRotation(GetPositionFromPixelSize(new(53, 91), new(-5, -5), new(64, 96), 16), Quaternion.Euler(0, 0, 180));
        SpriteRenderer infirstNumberSP = infirstNumber.AddComponent<SpriteRenderer>();
        infirstNumberSP.sprite = ((this.suit == Suits.diamond || this.suit == Suits.heart) ? redLetterSprites : letterSprites)[3];
        infirstNumberSP.sortingOrder = 1;

        GameObject queen = new("Queen");
        queen.transform.parent = this.transform;
        queen.transform.SetLocalPositionAndRotation(new(), new());
        queen.transform.localScale = Vector3.one;
        SpriteRenderer queenSP = queen.AddComponent<SpriteRenderer>();
        queenSP.sprite = ((this.suit == Suits.diamond || this.suit == Suits.heart) ? redFigureSprites : figureSprites)[2];
        queenSP.sortingOrder = 1;
    }

    private void CreateKingCard()
    {
        GameObject background = new("Background");
        background.transform.parent = this.transform;
        background.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
        background.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/base-card");

        GameObject suit = new("Suit");
        suit.transform.parent = this.transform;
        suit.transform.SetLocalPositionAndRotation(GetPositionFromPixelSize(new(5, 5), new(5, 5), new(64, 96), 16), Quaternion.identity);
        SpriteRenderer suitSP = suit.AddComponent<SpriteRenderer>();
        suitSP.sprite = suitSprites[(int)this.suit];
        suitSP.sortingOrder = 1;

        GameObject firstNumber = new("Letter");
        firstNumber.transform.parent = this.transform;
        firstNumber.transform.SetLocalPositionAndRotation(GetPositionFromPixelSize(new(11, 5), new(5, 5), new(64, 96), 16), Quaternion.identity);
        SpriteRenderer firstNumberSP = firstNumber.AddComponent<SpriteRenderer>();
        firstNumberSP.sprite = ((this.suit == Suits.diamond || this.suit == Suits.heart) ? redLetterSprites : letterSprites)[2];
        firstNumberSP.sortingOrder = 1;

        GameObject insuit = new("InvertedSuit");
        insuit.transform.parent = this.transform;
        insuit.transform.SetLocalPositionAndRotation(GetPositionFromPixelSize(new(59, 91), new(-5, -5), new(64, 96), 16), Quaternion.Euler(0, 0, 180));
        SpriteRenderer insuitSP = insuit.AddComponent<SpriteRenderer>();
        insuitSP.sprite = suitSprites[(int)this.suit];
        insuitSP.sortingOrder = 1;

        GameObject infirstNumber = new("InvertedLetter");
        infirstNumber.transform.parent = this.transform;
        infirstNumber.transform.SetLocalPositionAndRotation(GetPositionFromPixelSize(new(53, 91), new(-5, -5), new(64, 96), 16), Quaternion.Euler(0, 0, 180));
        SpriteRenderer infirstNumberSP = infirstNumber.AddComponent<SpriteRenderer>();
        infirstNumberSP.sprite = ((this.suit == Suits.diamond || this.suit == Suits.heart) ? redLetterSprites : letterSprites)[2];
        infirstNumberSP.sortingOrder = 1;

        GameObject king = new("King");
        king.transform.parent = this.transform;
        king.transform.SetLocalPositionAndRotation(new(), new());
        king.transform.localScale = Vector3.one;
        SpriteRenderer kingSP = king.AddComponent<SpriteRenderer>();
        kingSP.sprite = ((this.suit == Suits.diamond || this.suit == Suits.heart) ? redFigureSprites : figureSprites)[1];
        kingSP.sortingOrder = 1;
    }

    private void CreateComponent(string name, Sprite sprite, Vector3 position, int sortingOrder = 1)
    {
        GameObject componentObject = new GameObject(name);
        componentObject.transform.parent = transform;

        SpriteRenderer renderer = componentObject.AddComponent<SpriteRenderer>();
        renderer.sprite = sprite;
        renderer.sortingOrder = sortingOrder;

        componentObject.transform.localPosition = position;
    }

    private void CreateInvertedComponent(string name, Sprite sprite, Vector3 position, int sortingOrder = 1)
    {
        GameObject componentObject = new GameObject("Inverted" + name);
        componentObject.transform.parent = transform;

        SpriteRenderer renderer = componentObject.AddComponent<SpriteRenderer>();
        renderer.sprite = sprite;
        renderer.sortingOrder = sortingOrder;

        componentObject.transform.localPosition = position;
        componentObject.transform.rotation = Quaternion.Euler(0, 0, 180);
    }

    private Vector3 GetPositionFromPixelSize(Vector2 position, Vector2 size, Vector2 backgroundSize, int pixelsPerUnit)
    {
        Vector3 vector3 = new((2 * position.x + size.x - backgroundSize.x) / (2 * pixelsPerUnit), (-2 * position.y - size.y + backgroundSize.y) / (2 * pixelsPerUnit), 0);

        return vector3;
    }

    private void SetCardType()
    {
        CardTypes cardTypes = value switch
        {
            <= 99 when value == 0 => CardTypes.zero,
            <= 99 when value == 1 => CardTypes.ace,
            <= 99 when value > 1 && value < 11 => CardTypes._default,
            <= 99 when value == 11 => CardTypes.jack,
            <= 99 when value == 12 => CardTypes.queen,
            <= 99 when value == 13 => CardTypes.king,
            <= 99 when value > 13 => CardTypes.big,
            _ => CardTypes._null,
        };
        cardType = cardTypes;
    }
}

public class Player
{
    public List<Card> hand;

    public void InitializePlayer()
    {
        hand = new List<Card>();
    }
}

public class Deck
{
    public List<Card> cards = new();

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
        else
        {
            Debug.LogWarning("No cards left in the deck!");
            return null;
        }
    }
}

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
        return rank.ToString() + " of " + Enum.GetName(typeof(Suits), suit);
    }
}