using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject Pausemenu;

    [SerializeField]
    private bool IsPause;

    [SerializeField]
    private GameObject Settingmenu;

    [SerializeField]
    private GameObject MusicOn;

    [SerializeField]
    private GameObject MusicOff;

    [SerializeField]
    private GameObject Block;

    // Start is called before the first frame update
    void Start()
    {
        Pausemenu.SetActive(false);
        Settingmenu.SetActive(false);
        Block.SetActive(false);
        SetSoundState();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPause)
            {
                Resume();
                Settingmenu.SetActive(false);
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Pausemenu.SetActive(false);
        Block.SetActive(false);
        Time.timeScale = 1f;
        IsPause = false;
    }

    public void Pause()
    {
        Pausemenu.SetActive(true);
        Block.SetActive(true);
        Time.timeScale = 0f;
        IsPause = true;
    }
    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenu");
    }
    public void Setting()
    {
        Settingmenu.SetActive(true);
        Pausemenu.SetActive(false);
    }

    public void Back()
    {
        Pausemenu.SetActive(true);
        Settingmenu.SetActive(false);
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

