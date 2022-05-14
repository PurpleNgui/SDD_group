using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomButtonScript : MonoBehaviour
{
    [SerializeField]
    private int xPos;
    [SerializeField]
    private int yPos;

    public GameObject InteractiveObject;

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
        xPos = Random.Range(-480, 480);
        yPos = Random.Range(-270, 270);
        InteractiveObject.transform.position = new Vector2(xPos, yPos);
        Debug.Log(xPos + " " + yPos);
    }

}
