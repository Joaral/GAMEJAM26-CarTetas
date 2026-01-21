using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class cardsHandler : MonoBehaviour
{
    public GameManager gameManager;
    public List<GameObject> cards;
    public Transform spawnPoint;
    public GameObject sobre;
    public GameObject currentSobre;
    public Animator animator;
    public Vector3 SobreToPosition;

    public float speed = 10;

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
        currentSobre = Instantiate(sobre, new Vector3 (-8, 0.3f, -3), Quaternion.Euler (0,-90,-90));
        StartCoroutine(MoveSobre(SobreToPosition));

        animator = currentSobre.GetComponent<Animator>();
        animator.SetBool("open", true);
        
        if (gameManager.gameOver) return;

        int cardIndex = Random.Range(0, cards.Count);
        currentCard = Instantiate(cards[cardIndex], spawnPoint.position, spawnPoint.rotation);
        
        isCardAlive = true;
        gameManager.SetCurrentCard(currentCard);
    }

    public void CardResolved()
    {
        //StartCoroutine(MoveSobre(new Vector3(SobreToPosition.x, SobreToPosition.y, -6)));
        //Destroy(currentSobre);

        animator = currentSobre.GetComponent<Animator>();
        animator.SetBool("open", false);
        Destroy(gameManager.currentCard);
        isCardAlive = false;
    }

    public IEnumerator MoveSobre(Vector3 target)
    {
        float time = 0f;
        Vector3 startPos = currentSobre.transform.position;

        while (time < 1f)
        {
            time += Time.deltaTime * speed;
            currentSobre.transform.position = Vector3.Lerp(startPos, target, time);
            yield return null;
        }
    }

}
