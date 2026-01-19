using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float tiempo = 60f;
    public TextMeshProUGUI textMeshPro;

    void Update()
    {

        textMeshPro.text = Mathf.Ceil(tiempo).ToString();

        if (tiempo > 0)
        {
            tiempo -= Time.deltaTime;
            Debug.Log(Mathf.Ceil(tiempo));
        }
        else
        {
            tiempo = 0;
            Debug.Log("Tiempo terminado");
        }
    }
}

