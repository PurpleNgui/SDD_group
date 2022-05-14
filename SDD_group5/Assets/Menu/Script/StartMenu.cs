using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject mainmenu;

    [SerializeField]
    private GameObject optionmenu;

    [SerializeField]
    private GameObject MusicOn;

    [SerializeField]
    private GameObject MusicOff;

    // Start is called before the first frame update
    void Start()
    {
        optionmenu.SetActive(false);
        SetSoundState();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("MazeScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Mainmenu()
    {
        mainmenu.SetActive(false);
    }
    public void Optionmenu()
    {
        optionmenu.SetActive(true);
    }

    public void Resume()
    {
        optionmenu.SetActive(false);
        mainmenu.SetActive(true);
    }
    public void Mute()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            PlayerPrefs.SetInt("Muted", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Muted", 0);
        }

        SetSoundState();
    }

    public void SetSoundState()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            AudioListener.volume = 1;
            MusicOn.SetActive(true);
            MusicOff.SetActive(false);
        }
        else
        {
            AudioListener.volume = 0;
            MusicOn.SetActive(false);
            MusicOff.SetActive(true);
        }
    }
}
