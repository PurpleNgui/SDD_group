using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleScript : MonoBehaviour
{
    public Vector3 targetPos;
    private Vector3 correctPos;

    public int number;

    public bool inRightPlace;

    //For debugging
    //private SpriteRenderer _sprite;

    void Awake()
    {
        targetPos = transform.position;
        correctPos = transform.position;

        //For debugging
        //_sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.position = Vector3.Lerp(a: transform.position, b: targetPos, t: 0.05f);
        if (targetPos == correctPos)
        {
            //For debugging
            //_sprite.color = Color.green;

            inRightPlace = true;
        }
        else
        {
            //For debugging
            //_sprite.color = Color.white;

            inRightPlace = false;
        }
    }
}
