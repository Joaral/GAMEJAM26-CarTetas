using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class cardsHandler : MonoBehaviour
{
    public GameManager gameManager;
    public List<GameObject> cards;
    public Transform spawnPoint;

    public GameObject currentCard;
    public bool isCardAlive;

    InputSystem_Actions input;

    void Start()
    {
        input = new InputSystem_Actions();
        input.Enable();

        SpawnCard();
    }

    void Update()
    {
        if (gameManager.gameOver) return;

        //if (input.Player.Next.WasPressedThisFrame())
        //{
        if (!isCardAlive)
            {
                SpawnCard();
            }
        //}
    }

    void SpawnCard()
    {
        if (gameManager.gameOver) return;

        int cardIndex = Random.Range(0, cards.Count);
        currentCard = Instantiate(cards[cardIndex], spawnPoint.position, spawnPoint.rotation);
        isCardAlive = true;
        gameManager.SetCurrentCard(currentCard);
    }

    public void CardResolved()
    {
        isCardAlive = false;
    }
}
