using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float tiempo = 60f;
    public TextMeshProUGUI textMeshPro;
    public GameManager gameManager;


    bool finished;

    void Update()
    {
        if (finished) return;

        tiempo -= Time.deltaTime;
        tiempo = Mathf.Max(tiempo, 0);

        textMeshPro.text = Mathf.Ceil(tiempo).ToString();

        if (tiempo <= 0)
        {
            finished = true;
            gameManager.EndGame();
        }
    }

}


