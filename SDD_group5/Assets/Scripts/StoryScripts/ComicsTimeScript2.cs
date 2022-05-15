using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComicsTimeScript2 : MonoBehaviour
{
    float timer = 0;

    int currentPage = 1;

    public GameObject comic1;
    public GameObject comic2;
    //public GameObject comic3;

    public GameObject nextPageButton;

    // Update is called once per frame
    void Update()
    {
        if (timer <= 3 && currentPage == 1)
        {
            nextPageButton.SetActive(false);
            timer += Time.deltaTime;
            //Debug.Log("1: " + timer);
            if (timer >= 2)
            {
                comic1.SetActive(true);
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
                comic2.SetActive(true);
                nextPageButton.SetActive(true);
            }
        }
        //else if (timer <= 2 && currentPage == 3)
        //{
        //    nextPageButton.SetActive(false);
        //    timer += Time.deltaTime;
        //    //Debug.Log("3: " + timer);
        //    if (timer >= 1)
        //    {
        //        comic3.SetActive(true);
        //        nextPageButton.SetActive(true);
        //    }
        //}

    }

    public void NextPage()
    {
        if (currentPage == 1)
        {
            comic1.SetActive(false);
            timer = 0;
            currentPage++;
        }
        else if (currentPage == 2)
        {
            SceneManager.LoadScene("BirdGameScene");
        }
        //else if (currentPage == 3)
        //{
        //    SceneManager.LoadScene("BirdGameScene");
        //}
    }
}
