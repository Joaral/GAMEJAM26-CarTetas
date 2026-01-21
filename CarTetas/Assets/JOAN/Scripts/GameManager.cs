using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public InputSystem_Actions input;
    public cardsHandler cardsHandler;

    public GameObject currentCard;

    public int score = 0;
    public bool gameOver;
    public GameObject scorePanel;
    public GameObject currentGamePanel;
    public TextMeshProUGUI finalScoreText;
    public bool isPaused;
    public bool isFlipped = false;
    public GameObject pausePanel;

    public GameObject AreaLove;
    public GameObject AreaDead;
    public GameObject AreaJob;
    public ListHandler listHandler;


    void Start()
    {
        input = new InputSystem_Actions();
        input.Enable();
    }

    void Update()
    {

        if (input.Player.Pause.WasPressedThisFrame())
        {
            TogglePause();
        }

        if (gameOver || isPaused) return;

        if (currentCard == null) return;

        if (input.Player.Love.WasPressedThisFrame())
        {
            ResolveCard(AreaLove);
        }

        if (input.Player.Dead.WasPressedThisFrame())
        {
            ResolveCard(AreaDead);
        }

        if (input.Player.Job.WasPressedThisFrame())
        {
            ResolveCard(AreaJob);
        }
        if (input.Player.Flip.WasPressedThisFrame())
        {
            FlipCard();
        }
    }

    void ResolveCard(GameObject area)
    {
        //currentCard.transform.position = area.transform.position;

        cardsHandler.StartCoroutine(cardsHandler.MoveSobre(area.transform.position));

        if (currentCard.CompareTag(area.tag))
        {
            Debug.Log("CORRECTO");
            score += 10;

        }
        else
        {
            Debug.Log("INCORRECTO");
            score -= 5;
            if(score < 0) score = 0;

        }
        cardsHandler.CardResolved();
        currentCard = null;
    }

    public void SetCurrentCard(GameObject card)
    {
        currentCard = card;
        listHandler.SetTextByCard(card);
    }

    public void EndGame()
    {
        gameOver = true;
        Destroy(currentCard);
        currentGamePanel.SetActive(false);
        scorePanel.SetActive(true);
        finalScoreText.text = score.ToString();
        Debug.Log("GAME OVER");
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        if (currentCard != null) currentCard.SetActive(!isPaused);
        pausePanel.SetActive(isPaused);

        Time.timeScale = isPaused ? 0f : 1f;
    }

    public void FlipCard()
    {
        if (currentCard == null) return;

        isFlipped = !isFlipped;

        Vector3 euler = currentCard.transform.eulerAngles;

        currentCard.GetComponentInChildren<Canvas>().enabled = !isFlipped;
        euler.z += 180f;
        currentCard.transform.eulerAngles = euler;
    }



}

