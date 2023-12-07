using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainGame : MonoBehaviour
{
    public BlackjackGame game;
    public BlackjackGame.Player player;
    public TextMeshProUGUI playerCounter, dealerCounter, menuMessage;

    public GameObject menu;

    bool finishedGame = false;

    void Start()
    {
        CreateNewGame();
    }

    // Update is called once per frame
    void Update()
    {
        DrawCards();
        ChangeCounters();
    }

    public void CreateNewGame()
    {
        menu.SetActive(false);
        player = new BlackjackGame.Player();
        game = new BlackjackGame(new List<BlackjackGame.Player> { player });
        game.DealInitialHands();

        finishedGame = false;
    }

    public void PlayerWithdraw()
    {
        if (!finishedGame)
        {
            game.PlayerHit(player);

            if (game.PlayerBusted(player))
            {
                Stand();
            }
        }
    }

    public void Stand()
    {
        if (!finishedGame)
        {
            game.DealerPlay();

            if (game.PlayerWins(player))
            {
                Debug.Log("Player wins!");
                menuMessage.text = "EL JUGADOR HA GUANYAT";
            }
            else
            {
                Debug.Log("Player looses!");
                menuMessage.text = "EL JUGADOR HA PERDUT";
            }
            menu.SetActive(true);

            finishedGame = true;
        }
    }

    public void DrawCards()
    {
        for (int i = 0; i < player.hand.Count; i ++)
        {
            MoveOrCreateCard(player.hand[i], new Vector3(12f / (player.hand.Count + 1) * (i + 1) - 6, -3.5f, 0), i);
        }

        for (int i = 0; i < game.dealerHand.Count; i++)
        {
            MoveOrCreateCard(game.dealerHand[i], new Vector3(-12f / (game.dealerHand.Count + 1) * (i + 1) + 6, 3.5f, 0), i);
        }
    }

    public void ChangeCounters()
    {
        playerCounter.text = game.CalculateHandValue(player.hand).ToString();
        dealerCounter.text = game.CalculateHandValue(game.dealerHand).ToString();
    }

    public void MoveOrCreateCard(BlackjackGame.Card card, Vector3 position, int count)
    {
        if (GameObject.Find(card.ToString()) == null)
        {
            GameObject n_card = new(card.ToString());
            n_card.AddComponent<CardAssembler>().SetValues(card.suit, card.rank, count);
        }


        GameObject.Find(card.ToString()).transform.position = position;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("SinglePlayer");
    }
}
