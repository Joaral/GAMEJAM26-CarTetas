using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public InputSystem_Actions input;
    public cardsHandler cardsHandler;

    public GameObject currentCard;
    public TextMeshProUGUI textMeshPro;
    public int score = 0;
    public bool gameOver;
    public GameObject scorePanel;
    public TextMeshProUGUI finalScoreText;
    public bool isPaused;
    public GameObject pausePanel;

    public GameObject AreaLove;
    public GameObject AreaDead;
    public GameObject AreaJob;

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
    }

    void ResolveCard(GameObject area)
    {
        currentCard.transform.position = area.transform.position;

        if (currentCard.CompareTag(area.tag))
        {
            Debug.Log("CORRECTO");
            score += 10;
            textMeshPro.text = "Score: " + score.ToString();
        }
        else
        {
            Debug.Log("INCORRECTO");
            score -= 5;
            if(score < 0) score = 0;
            textMeshPro.text = "Score: " + score.ToString();
        }

        cardsHandler.CardResolved();
        currentCard = null;
    }

    public void SetCurrentCard(GameObject card)
    {
        currentCard = card;
    }

    public void EndGame()
    {
        gameOver = true;
        scorePanel.SetActive(true);
        finalScoreText.text = "Puntuacion final: " + score.ToString();
        Debug.Log("GAME OVER");
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        pausePanel.SetActive(isPaused);

        Time.timeScale = isPaused ? 0f : 1f;
    }


}

