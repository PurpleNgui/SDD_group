using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComicsTimeScript3 : MonoBehaviour
{
    float timer = 0;

    int currentPage = 1;

    public GameObject comic1;
    public GameObject comic2;
    public GameObject comic3;
    public GameObject comic4;
    public GameObject comic5;
    public GameObject comic6;
    public GameObject comic7;
    public GameObject timeLater;

    public GameObject thxText;
    public GameObject thxPanel;
    public GameObject QAPanel;

    public GameObject nextPageButton;

    // Update is called once per frame
    void Update()
    {
        if (timer <= 5 && currentPage == 1)
        {
            nextPageButton.SetActive(false);
            timer += Time.deltaTime;
            //Debug.Log("1: " + timer);
            if (timer >= 2)
            {
                comic1.SetActive(true);
            }
            if(timer >= 4)
            {
                comic2.SetActive(true);
                nextPageButton.SetActive(true);
            }
        }
        else if (timer <= 2 && currentPage == 2)
        {
            nextPageButton.SetActive(false);
            timer += Time.deltaTime;
            //Debug.Log("2: " + timer);
            if (timer >= 1)
            {
                timeLater.SetActive(true);
                nextPageButton.SetActive(true);
            }
        }
        else if (timer <= 2 && currentPage == 3)
        {
            nextPageButton.SetActive(false);
            timer += Time.deltaTime;
            //Debug.Log("2: " + timer);
            if (timer >= 1)
            {
                comic3.SetActive(true);
                nextPageButton.SetActive(true);
            }
        }
        else if (timer <= 4 && currentPage == 4)
        {
            nextPageButton.SetActive(false);
            timer += Time.deltaTime;
            //Debug.Log("3: " + timer);
            if (timer >= 1)
            {
                comic4.SetActive(true);
            }
            if(timer >= 3)
            {
                comic5.SetActive(true);
                nextPageButton.SetActive(true);
            }
        }
        else if (timer <= 4 && currentPage == 5)
        {
            nextPageButton.SetActive(false);
            timer += Time.deltaTime;
            //Debug.Log("3: " + timer);
            if (timer >= 1)
            {
                comic6.SetActive(true);
            }
            if(timer >= 3)
            {
                comic7.SetActive(true);
                nextPageButton.SetActive(true);
            }
        }

    }

    public void NextPage()
    {
        if (currentPage == 1)
        {
            comic1.SetActive(false);
            comic2.SetActive(false);
            timer = 0;
            currentPage++;
        }
        else if (currentPage == 2)
        {
            timeLater.SetActive(false);
            timer = 0;
            currentPage++;
        }
        else if (currentPage == 3)
        {
            comic3.SetActive(false);
            timer = 0;
            currentPage++;
        }
        else if (currentPage == 4)
        {
            comic4.SetActive(false);
            comic5.SetActive(false);
            timer = 0;
            currentPage++;
        }
        else if (currentPage == 5)
        {
            comic6.SetActive(false);
            comic7.SetActive(false);
            currentPage++;
            thxPanel.SetActive(true);
        }
        else if (currentPage == 6)
        {
            nextPageButton.SetActive(false);
            thxText.SetActive(false);
            QAPanel.SetActive(true);
            currentPage++;

        }
        //else if (currentPage == 6)
        //{
        //    thxText.SetActive(false);
        //    currentPage++;
        //}
    }

    public void Menu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
