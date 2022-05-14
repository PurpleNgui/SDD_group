using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    //private float speed = 3f;
    
    private int xPos;
    private int yPos;

    private int combo = 0;
    private int NumberOfFishingNet = 6;

    public GameObject InteractiveObject;
    public GameObject FishingNet1;
    public GameObject FishingNet2;
    public GameObject FishingNet3;
    public GameObject FishingNet4;
    public GameObject FishingNet5;
    public GameObject FishingNet6;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void RandomPosition()
    {
        xPos = Random.Range(110, 1810);
        yPos = Random.Range(140, 940);
        InteractiveObject.transform.position = new Vector2(xPos, yPos);

        combo++;
        Debug.Log(combo);

        if (combo == 6) { CutFishingNet(); }
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
    }
}
