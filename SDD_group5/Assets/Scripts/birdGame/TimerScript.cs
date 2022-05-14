using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    bool startGame = false;
    bool endGame = false;

    float qteTime = 3f;
    float booldTime = 0.5f;
    float redButtonTime = 0;
    float redButtonDownTime = 2f;
    float startCountDownTime = 3f;

    int injuried = 0;

    public GameObject button;
    public GameObject RedButton;
    public GameObject buttonCanvas;
    public GameObject boold;

    public GameObject startCountDownTimeGO;
    public Text startCountDownTimeText;

    public GameObject restartUI;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        redButtonTime = Random.Range(5, 11);
    }

    // Update is called once per frame
    void Update()
    {
        if(startGame == false)
        {
            if (startCountDownTime >= 0)
            {
                startCountDownTimeGO.SetActive(true);
                startCountDownTime -= Time.deltaTime;
            }
            else
            {
                Destroy(startCountDownTimeGO, 1f);
                startGame = true;
            }
            startCountDownTimeText.text = Mathf.Ceil(startCountDownTime).ToString();
        }

        if (startGame == true || endGame == true)
        {
            if (button.activeInHierarchy)
            {
                qteTime -= Time.deltaTime;
                if (qteTime <= 0)
                {
                    buttonCanvas.SendMessage("GBRandomPosition");
                    Injuried();
                    if (ButtonScript.GetNumberOfFishingNet() >= 4)
                    {
                        qteTime = 3;
                    }
                    else if (ButtonScript.GetNumberOfFishingNet() >= 2)
                    {
                        qteTime = 2;
                    }
                    else if (ButtonScript.GetNumberOfFishingNet() == 1)
                    {
                        qteTime = 1;
                    }
                    else
                    {
                        qteTime = 10;
                        button.SetActive(false);
                    }
                }
            }

            if (boold.activeInHierarchy)
            {
                booldTime -= Time.deltaTime;
                if (booldTime <= 0)
                {
                    boold.SetActive(false);
                    booldTime = 0.5f;
                }
            }


            redButtonTime -= Time.deltaTime;
            if (redButtonTime <= 0)
            {
                buttonCanvas.SendMessage("RBRandomPosition");
                RedButton.SetActive(true);
                redButtonTime = Random.Range(5, 11);
            }

            if (RedButton.activeInHierarchy)
            {
                redButtonDownTime -= Time.deltaTime;
                if (redButtonDownTime <= 0)
                {
                    RedButton.SetActive(false);
                    redButtonDownTime = 2f;
                }
            }
        }
    }

    public void ResetQteTime()
    {
        if (ButtonScript.GetNumberOfFishingNet() >= 4)
        {
            qteTime = 3;
        }
        else if (ButtonScript.GetNumberOfFishingNet() >= 2)
        {
            qteTime = 2;
        }
        else if (ButtonScript.GetNumberOfFishingNet() == 1)
        {
            qteTime = 1;
        }
        else
        {
            qteTime = 10;
            button.SetActive(false);
            SceneManager.LoadScene("StoryScene");
        }
    }

    public void Injuried()
    {
        injuried++;
        Debug.Log("injuried" + injuried);
        boold.SetActive(true);
        if (injuried == 4)
        {
            endGame = true;
            restartUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
