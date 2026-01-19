using UnityEngine;

public class GameManager : MonoBehaviour
{
    public InputSystem_Actions input;
    public cardsHandler cardsHandler;
    public GameObject Object;
    public Vector3 newPosition;
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
       
        if (input.Player.Love.IsPressed())
        {
            newPosition = new Vector3(AreaLove.transform.position.x, AreaLove.transform.position.y, AreaLove.transform.position.z);
            Object.transform.position = newPosition;
            cardsHandler.isCardAlive = false;
            if (Object.tag == AreaLove.tag)
            {
                Debug.Log("TETAS");
            }
            else
            {
                Debug.Log("NO TETAS");
            }

        }
        if (input.Player.Dead.IsPressed())
        {
            newPosition = new Vector3(AreaDead.transform.position.x, AreaDead.transform.position.y, AreaDead.transform.position.z);
            Object.transform.position = newPosition;
            cardsHandler.isCardAlive = false;
            if (Object.tag == AreaDead.tag)
            {
                Debug.Log("TETAS");
            }
            else
            {
                Debug.Log("NO TETAS");
            }
        }
        if (input.Player.Job.IsPressed())
        {
            newPosition = new Vector3(AreaJob.transform.position.x, AreaJob.transform.position.y, AreaJob.transform.position.z);
            Object.transform.position = newPosition;
            cardsHandler.isCardAlive = false;
            if (Object.tag == AreaJob.tag)
            {
                Debug.Log("TETAS");
            }
            else
            {
                Debug.Log("NO TETAS");
            }
        }
    }
}
