using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject credits;
    public GameObject options;
    public GameObject controls;

    public bool controlsB = false;

    public Slider musicSlider;
    public AudioMixer mainMixer;
    const string PREF_MUSIC = "MusicVolume";
    const string MIXER_MUSIC = "MusicVolume";

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            controlsB = !controlsB;
            controls.SetActive(controlsB);
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene("EmiScene");
    }

    public void Credits()
    {
        credits.SetActive(true);
        mainMenu.SetActive(false);
        options.SetActive(false);
    }

    public void Options()
    {
        options.SetActive(true);
        credits.SetActive(false);
        mainMenu.SetActive(false);
    }

    public void goBack()
    {
        credits.SetActive(false);
        options.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void OnMusicVolumeChanged(float value)
    {
        ApplyMusic(value);
        PlayerPrefs.SetFloat(PREF_MUSIC, value);
        PlayerPrefs.Save();
    }

    void ApplyMusic(float value)
    {
        float dB = Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20f;
        mainMixer.SetFloat(MIXER_MUSIC, dB);
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
