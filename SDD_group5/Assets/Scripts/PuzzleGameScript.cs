using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGameScript : MonoBehaviour
{
    [SerializeField]
    private Transform emptySpace = null;

    private Camera _camera;

    [SerializeField]
    private PuzzleScript[] puzzles;

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit)
            {
                if (Vector2.Distance(a: emptySpace.position, b: hit.transform.position) < 2.5)
                {
                    Vector2 lastEmptySpacePos = emptySpace.position;
                    PuzzleScript thisPuzzle = hit.transform.GetComponent<PuzzleScript>();
                    emptySpace.position = thisPuzzle.targetPos;
                    thisPuzzle.targetPos = lastEmptySpacePos;
                }
            }
        }
    }
}
