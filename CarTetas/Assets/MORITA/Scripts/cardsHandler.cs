using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class cardsHandler : MonoBehaviour
{
    public GameManager gameManager;
    public List<GameObject> cards;
    public GameObject currentCard;
    public bool isCardAlive;
    public bool canSpawn;
    //public Timer timer;
    public int cardIndex;
    public Transform spawnPoint;
    InputSystem_Actions input;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        input = new InputSystem_Actions();
        input.Enable();
    }

    // Update is called once per frame
    void Update()
    {



        if (isCardAlive)
        {
            canSpawn = false;
        }
        else
        {
            cardIndex = Random.Range(0, cards.Count);
            canSpawn = true;
        }



        if (canSpawn)
        {
            currentCard = Instantiate(cards[cardIndex], spawnPoint.position, spawnPoint.rotation);
            isCardAlive = true;
            canSpawn = false;
            gameManager.Object = currentCard;
        }


        if (input.Player.Next.IsPressed())
        {
            if (!isCardAlive)
            {
                Destroy(currentCard);
                currentCard = null;
            }
            else
            {
                Debug.Log("Pendejo");
            }

        }
        
    }
}
