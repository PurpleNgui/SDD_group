using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{ 
    private int xPos;
    private int yPos;
    private int x;
    private int y;

    private int combo = 0;
    private static int NumberOfFishingNet = 6;

    public GameObject Timer;
    public GameObject InteractiveObject;
    public GameObject RedButton;
    public GameObject FishingNet1;
    public GameObject FishingNet2;
    public GameObject FishingNet3;
    public GameObject FishingNet4;
    public GameObject FishingNet5;
    public GameObject FishingNet6;
    //public GameObject b;

    public AudioClip cutSound;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    
    }


    public void ClickGreenButton()
    {
        combo++;
        Timer.SendMessage("ResetQteTime");
        Debug.Log(combo);


        if (combo == 6) 
        { 
            CutFishingNet(); 
        }

        GBRandomPosition();
    }

    public void ClickRedButton()
    {
        Timer.SendMessage("Injuried");
        RedButton.SetActive(false);
    }

    public void GBRandomPosition()
    {
        xPos = Random.Range(110, 1810);
        yPos = Random.Range(140, 940);
        InteractiveObject.transform.position = new Vector2(xPos, yPos);
    }

    public void RBRandomPosition()
    {
        x = Random.Range(30, 50);
        y = Random.Range(-50, 50);
        RedButton.transform.position = new Vector2(xPos+x, yPos+y);
    }

    public void CutFishingNet()
    {
        if(NumberOfFishingNet == 6)
        {
            Destroy(FishingNet1, 1);
            NumberOfFishingNet--;
            combo = 0;
        }else if(NumberOfFishingNet == 5)
        {
            Destroy(FishingNet2, 1);
            NumberOfFishingNet--;
            combo = 0;
        }
        else if(NumberOfFishingNet == 4)
        {
            Destroy(FishingNet3, 1);
            NumberOfFishingNet--;
            combo = 0;
        }
        else if (NumberOfFishingNet == 3)
        {
            Destroy(FishingNet4, 1);
            NumberOfFishingNet--;
            combo = 0;
        }
        else if (NumberOfFishingNet == 2)
        {
            Destroy(FishingNet5, 1);
            NumberOfFishingNet--;
            combo = 0;
        }
        else
        {
            Destroy(FishingNet6, 2);
            NumberOfFishingNet--;
            combo = 0;
        }
        audioSource.PlayOneShot(cutSound);
    }

    public void Restart()
    {
        SceneManager.LoadScene("BirdGameScene");
    }

    public static int GetNumberOfFishingNet()
    {
        return NumberOfFishingNet;
    }

    public static void SetNumberOfFishingNet(int n)
    {
        NumberOfFishingNet = n;
    }
}
