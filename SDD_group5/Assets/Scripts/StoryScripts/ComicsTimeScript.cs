using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComicsTimeScript : MonoBehaviour
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
    public GameObject comic8;
    public GameObject comic9;
    public GameObject comic10;
    public GameObject comic11;
    public GameObject comic12;
    public GameObject comic13;
    public GameObject comic14;
    public GameObject comic15;
    public GameObject comic16;
    public GameObject comic17;

    public GameObject nextPageButton;

    // Update is called once per frame
    void Update()
    {
        if (timer <= 13 && currentPage == 1)
        {
            nextPageButton.SetActive(false);
            timer += Time.deltaTime;
            //Debug.Log("1: " + timer);
            if (timer >= 2)
            {
                comic1.SetActive(true);
            }
            if (timer >= 4)
            {
                comic2.SetActive(true);
            }
            if (timer >= 6)
            {
                comic3.SetActive(true);
            }
            if (timer >= 8)
            {
                comic4.SetActive(true);
            }
            if (timer >= 10)
            {
                comic5.SetActive(true);
            }
            if (timer >= 12)
            {
                comic6.SetActive(true);
                nextPageButton.SetActive(true);
            }
        }
        else if(timer <= 4 && currentPage == 2)
        {
            nextPageButton.SetActive(false);
            timer += Time.deltaTime;
            //Debug.Log("2: " + timer);
            if (timer >= 1)
            {
                comic7.SetActive(true);
            }
            if (timer >= 3)
            {
                comic8.SetActive(true);
                nextPageButton.SetActive(true);
            }
        }
        else if (timer <= 2 && currentPage == 3)
        {
            nextPageButton.SetActive(false);
            timer += Time.deltaTime;
            //Debug.Log("3: " + timer);
            if (timer >= 1)
            {
                comic9.SetActive(true);
                nextPageButton.SetActive(true);
            }
        }
        else if (timer <= 2 && currentPage == 4)
        {
            nextPageButton.SetActive(false);
            timer += Time.deltaTime;
            //Debug.Log("4: " + timer);
            if (timer >= 1)
            {
                comic10.SetActive(true);
                nextPageButton.SetActive(true);
            }
        }
        else if (timer <= 4 && currentPage == 5)
        {
            nextPageButton.SetActive(false);
            timer += Time.deltaTime;
            //Debug.Log("4: " + timer);
            if (timer >= 1)
            {
                comic11.SetActive(true);
            }
            if (timer >= 3)
            {
                comic12.SetActive(true);
                nextPageButton.SetActive(true);
            }
        }
        else if (timer <= 10 && currentPage == 6)
        {
            nextPageButton.SetActive(false);
            timer += Time.deltaTime;
            //Debug.Log("1: " + timer);
            if (timer >= 1)
            {
                comic13.SetActive(true);
            }
            if (timer >= 3)
            {
                comic14.SetActive(true);
            }
            if (timer >= 5)
            {
                comic15.SetActive(true);
            }
            if (timer >= 7)
            {
                comic16.SetActive(true);
            }
            if (timer >= 9)
            {
                comic17.SetActive(true);
                nextPageButton.SetActive(true);
            }
        }
    }

    public void NextPage()
    {
        if(currentPage == 1)
        {
            comic1.SetActive(false);
            comic2.SetActive(false);
            comic3.SetActive(false);
            comic4.SetActive(false);
            comic5.SetActive(false);
            comic6.SetActive(false);
            timer = 0;
            currentPage++;
        }
        else if (currentPage == 2)
        {
            comic7.SetActive(false);
            comic8.SetActive(false);
            timer = 0;
            currentPage++;
        }
        else if(currentPage == 3)
        {
            comic9.SetActive(false);
            timer = 0;
            currentPage++;
        }
        else if (currentPage == 4)
        {
            comic10.SetActive(false);
            timer = 0;
            currentPage++;
        }
        else if (currentPage == 5)
        {
            comic11.SetActive(false);
            comic12.SetActive(false);
            timer = 0;
            currentPage++;
        }
        else if (currentPage == 6)
        {
            SceneManager.LoadScene("PuzzleScene");
        }
    }
}
