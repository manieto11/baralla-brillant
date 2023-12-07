using UnityEngine;

public class CardAssembler : MonoBehaviour
{
    [SerializeField] private Sprite background;
    [SerializeField] private int count;

    [SerializeField] private Suits suit;

    [SerializeField] private Sprite[] suitSprites;


    [SerializeField] private CardTypes cardType;

    [SerializeField] private int rank;

    [SerializeField] private Sprite[] numberSprites;

    [SerializeField] private Sprite[] redNumberSprites;

    [SerializeField] private Sprite[] letterSprites;

    [SerializeField] private Sprite[] redLetterSprites;

    [SerializeField] private Sprite[] figureSprites;

    [SerializeField] private Sprite[] redFigureSprites;


    private void Awake()
    {
        background = Resources.Load<Sprite>("Sprites/base-card");

        suitSprites = Resources.LoadAll<Sprite>("Sprites/heart-diamond-spade-club");

        letterSprites = Resources.LoadAll<Sprite>("Sprites/letters");
        redLetterSprites = Resources.LoadAll<Sprite>("Sprites/red-letters");

        figureSprites = Resources.LoadAll<Sprite>("Sprites/figures");
        redFigureSprites = Resources.LoadAll<Sprite>("Sprites/red-figures");

        numberSprites = Resources.LoadAll<Sprite>("Sprites/numbers");
        redNumberSprites = Resources.LoadAll<Sprite>("Sprites/red-numbers");
    }

    private void Start()
    {
        SetCardType();

        if (cardType == CardTypes._default) CreateDefaultCard();
        else if (cardType == CardTypes.ace) CreateAceCard();
        else if (cardType == CardTypes.jack) CreateJackCard();
        else if (cardType == CardTypes.queen) CreateQueenCard();
        else if (cardType == CardTypes.king) CreateKingCard();
        // Add conditions for other card types as well.

        // Select suit sprite using the suit variable
        Sprite selectedSuitSprite = suitSprites[(int)suit];
        // Now, you can use selectedSuitSprite wherever you want to display the suit.
    }

    public void SetValues(Suits suit, int rank)
    {
        this.suit = suit;
        this.rank = rank;
    }

    public void SetValues(Suits suit, int rank, int count)
    {
        this.suit = suit;
        this.rank = rank;
        this.count = count;
    }

    private void SetCardType()
    {
        cardType = rank switch
        {
            0 => CardTypes.zero,
            1 => CardTypes.ace,
            _ => rank >= 2 && rank <= 10 ? CardTypes._default : rank == 11 ? CardTypes.jack : rank == 12 ? CardTypes.queen : rank == 13 ? CardTypes.king : CardTypes._null,
        };
    }

    private void CreateDefaultCard()
    {
        // Background
        CreateComponent("Background", background, new Vector3(0, 0, 0), 0);

        // Suit
        CreateComponent("Suit", suitSprites[(int)suit], new Vector3(-1.5625f, 2.375f, 0));

        // Inverted Suit
        CreateInvertedComponent("Suit", suitSprites[(int)suit], new Vector3(1.5625f, -2.375f, 0));

        // Number
        CreateComponent("Number", (suit == Suits.diamond || suit == Suits.heart) ? redNumberSprites[rank % 10] : numberSprites[rank % 10], new Vector3(-1.5625f, 1.9375f, 0));

        // Inverted Number
        CreateInvertedComponent("Number", (suit == Suits.diamond || suit == Suits.heart) ? redNumberSprites[rank % 10] : numberSprites[rank % 10], new Vector3(1.5625f, -1.9375f, 0));

        // Place Default Card Figures
        //PlaceDefaultCardFigures(1, 1);
    }

    private void CreateAceCard()
    {
        // Background
        CreateComponent("Background", background, new Vector3(0, 0, 0), 0);

        // Suit
        CreateComponent("Suit", suitSprites[(int)suit], new Vector3(-1.5625f, 2.375f, 0));

        // Inverted Suit
        CreateInvertedComponent("Suit", suitSprites[(int)suit], new Vector3(1.5625f, -2.375f, 0));

        // Letter
        CreateComponent("Letter", (suit == Suits.diamond || suit == Suits.heart) ? redLetterSprites[0] : letterSprites[0], new Vector3(-1.5625f, 1.9375f, 0));

        // Inverted Letter
        CreateInvertedComponent("Letter", (suit == Suits.diamond || suit == Suits.heart) ? redLetterSprites[0] : letterSprites[0], new Vector3(1.5625f, -1.9375f, 0));

        // Ace
        CreateComponent("Ace", suitSprites[(int)suit], new Vector3(0, 0, 0), new Vector3(3, 3, 0));
    }

    private void CreateJackCard()
    {
        // Background
        CreateComponent("Background", background, new Vector3(0, 0, 0), 0);

        // Suit
        CreateComponent("Suit", suitSprites[(int)suit], new Vector3(-1.5625f, 2.375f, 0));

        // Inverted Suit
        CreateInvertedComponent("Suit", suitSprites[(int)suit], new Vector3(1.5625f, -2.375f, 0));

        // Letter (Jack)
        CreateComponent("Letter", (suit == Suits.diamond || suit == Suits.heart) ? redLetterSprites[1] : letterSprites[1], new Vector3(-1.5625f, 1.9375f, 0));

        // Inverted Letter (Jack)
        CreateInvertedComponent("Letter", (suit == Suits.diamond || suit == Suits.heart) ? redLetterSprites[1] : letterSprites[1], new Vector3(1.5625f, -1.9375f, 0));

        // Jack figure
        CreateComponent("Jack", (suit == Suits.diamond || suit == Suits.heart) ? redFigureSprites[0] : figureSprites[0], new Vector3(0, 0, 0));
    }

    private void CreateQueenCard()
    {
        // Background
        CreateComponent("Background", background, new Vector3(0, 0, 0), 0);

        // Suit
        CreateComponent("Suit", suitSprites[(int)suit], new Vector3(-1.5625f, 2.375f, 0));

        // Inverted Suit
        CreateInvertedComponent("Suit", suitSprites[(int)suit], new Vector3(1.5625f, -2.375f, 0));

        // Letter (Queen)
        CreateComponent("Letter", (suit == Suits.diamond || suit == Suits.heart) ? redLetterSprites[3] : letterSprites[3], new Vector3(-1.5625f, 1.9375f, 0));

        // Inverted Letter (Queen)
        CreateInvertedComponent("Letter", (suit == Suits.diamond || suit == Suits.heart) ? redLetterSprites[3] : letterSprites[3], new Vector3(1.5625f, -1.9375f, 0));

        // Queen figure
        CreateComponent("Queen", (suit == Suits.diamond || suit == Suits.heart) ? redFigureSprites[2] : figureSprites[2], new Vector3(0, 0, 0));
    }

    private void CreateKingCard()
    {
        // Background
        CreateComponent("Background", background, new Vector3(0, 0, 0), 0);

        // Suit
        CreateComponent("Suit", suitSprites[(int)suit], new Vector3(-1.5625f, 2.375f, 0));

        // Inverted Suit
        CreateInvertedComponent("Suit", suitSprites[(int)suit], new Vector3(1.5625f, -2.375f, 0));

        // Letter (King)
        CreateComponent("Letter", (suit == Suits.diamond || suit == Suits.heart) ? redLetterSprites[2] : letterSprites[2], new Vector3(-1.5625f, 1.9375f, 0));

        // Inverted Letter (King)
        CreateInvertedComponent("Letter", (suit == Suits.diamond || suit == Suits.heart) ? redLetterSprites[2] : letterSprites[2], new Vector3(1.5625f, -1.9375f, 0));

        // King figure
        CreateComponent("King", (suit == Suits.diamond || suit == Suits.heart) ? redFigureSprites[1] : figureSprites[1], new Vector3(0, 0, 0));
    }

    private void CreateInvertedComponent(string name, Sprite sprite, Vector3 position, int sortingOrder = 1)
    {
        GameObject componentObject = new GameObject("Inverted" + name);
        componentObject.transform.parent = transform;

        SpriteRenderer renderer = componentObject.AddComponent<SpriteRenderer>();
        renderer.sprite = sprite;
        renderer.sortingOrder = sortingOrder + count * 2;

        componentObject.transform.localPosition = position;
        componentObject.transform.rotation = Quaternion.Euler(0, 0, 180);
    }


    private void CreateComponent(string name, Sprite sprite, Vector3 position, int sortingOrder = 1)
    {
        GameObject componentObject = new GameObject(name);
        componentObject.transform.parent = transform;

        SpriteRenderer renderer = componentObject.AddComponent<SpriteRenderer>();
        renderer.sprite = sprite;
        renderer.sortingOrder = sortingOrder + count * 2;

        componentObject.transform.localPosition = position;
    }

    private void CreateComponent(string name, Sprite sprite, Vector3 position, Vector3 scale, int sortingOrder = 1)
    {
        GameObject componentObject = new(name);
        componentObject.transform.parent = transform;

        SpriteRenderer renderer = componentObject.AddComponent<SpriteRenderer>();
        renderer.sprite = sprite;
        renderer.sortingOrder = sortingOrder + count * 2;

        componentObject.transform.localPosition = position;
        componentObject.transform.localScale = scale;
    }

    public enum Suits
    {
        club = 0,
        diamond = 1,
        heart = 2,
        spade = 3
    }

    public enum CardTypes
    {
        _default,
        ace,
        jack,
        queen,
        king,
        big,
        zero,
        _null
    }
}

