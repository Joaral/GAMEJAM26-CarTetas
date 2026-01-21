using UnityEngine;
using System.Collections;


public class Caja : MonoBehaviour
{
    public float speed = 10;
    public GameObject SOBRE;
    public Vector3 sobrePos;
    public bool isSobring;

    private bool isMoving;

    void Start()
    {
        SOBRE.SetActive(false);
        sobrePos = SOBRE.transform.position;
    }

    void Update()
    {
        if (isSobring && !isMoving)
        {
            SOBRE.SetActive(true);
            StartCoroutine(SobreToCaja());
        }
    }

    IEnumerator SobreToCaja()
    {
        isMoving = true;

        float time = 0f;
        Vector3 startPos = sobrePos;
        Vector3 target = new Vector3(startPos.x, -1f, startPos.z);

        SOBRE.transform.position = startPos;

        while (time < 1f)
        {
            time += Time.deltaTime;
            SOBRE.transform.position = Vector3.Lerp(startPos, target, time * speed);
            yield return null;
        }

        isSobring = false;
        isMoving = false;
        SOBRE.SetActive (false);
    }
}

