using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalScreen : MonoBehaviour
{
    public void startAgain()
    {
        SceneManager.LoadScene("EmiScene");
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MoritaMenuScene");
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
