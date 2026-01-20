using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class cardsHandler : MonoBehaviour
{
    public GameManager gameManager;
    public List<GameObject> cards;
    public Transform spawnPoint;
    public GameObject sobre;
    public Animator animator;

    public GameObject currentCard;
    public bool isCardAlive;

    InputSystem_Actions input;

    void Start()
    {
        input = new InputSystem_Actions();
        input.Enable();

        animator = sobre.GetComponent<Animator>();

        SpawnCard();
    }

    void Update()
    {
        if (gameManager.gameOver) return;

        if (input.Player.Next.WasPressedThisFrame())
        {
            if (!isCardAlive)
            {
                SpawnCard();
            }
        }
    }

    void SpawnCard()
    {
        Instantiate(sobre, new Vector3 (0, 0.3f, -3), Quaternion.Euler (0,-90,-90));
        animator.SetBool("open", true);
        
        if (gameManager.gameOver) return;

        int cardIndex = Random.Range(0, cards.Count);
        currentCard = Instantiate(cards[cardIndex], spawnPoint.position, spawnPoint.rotation);
        
        isCardAlive = true;
        gameManager.SetCurrentCard(currentCard);
    }

    public void CardResolved()
    {
        Destroy(sobre);
        animator.SetBool("open", false);
        isCardAlive = false;
    }
}
