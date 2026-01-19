using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject credits;

    public void StartGame()
    {
        SceneManager.LoadScene("MoritaScene");
    }

    public void Credits()
    {
        credits.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void goBack()
    {
        credits.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;   // Stop play mode in editor
#else
        Application.Quit();                                // Close the game in a build
#endif
    }

}
