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

    private int emptySpaceIndex = 15;

    private bool _isFinished;

    [SerializeField]
    private GameObject finishedPanel;

    [SerializeField]
    private AudioSource source;

    [SerializeField]
    private AudioClip puzzleSound;

    void Start()
    {
        _camera = Camera.main;

        Shuffle(); //random puzzle everytime
    }

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
                    //move puzzle
                    Vector2 lastEmptySpacePos = emptySpace.position;
                    PuzzleScript thisPuzzle = hit.transform.GetComponent<PuzzleScript>();
                    emptySpace.position = thisPuzzle.targetPos;
                    thisPuzzle.targetPos = lastEmptySpacePos;
                    source.PlayOneShot(puzzleSound);

                    int puzzleIndex = FindIndex(thisPuzzle);
                    puzzles[emptySpaceIndex] = puzzles[puzzleIndex];
                    puzzles[puzzleIndex] = null;
                    emptySpaceIndex = puzzleIndex;
                }
            }
        }

        if (!_isFinished)
        {
            int correctPuzzles = 0;
            foreach (var a in puzzles)
            {
                if (a != null)
                {
                    if (a.inRightPlace)
                        correctPuzzles++;
                }
            }

            if (correctPuzzles == puzzles.Length - 1)   //check is the puzzle finished
            {
                _isFinished = true;
                finishedPanel.SetActive(true);
            }
        }
    }

    public void Shuffle()   //generate random puzzle
    {
        int invertion;
        do
        {
            if (emptySpaceIndex != 15)
            {
                var puzzleOn15LastPos = puzzles[15].targetPos;
                puzzles[15].targetPos = emptySpace.position;
                emptySpace.position = puzzleOn15LastPos;
                puzzles[emptySpaceIndex] = puzzles[15];
                puzzles[15] = null;
                emptySpaceIndex = 15;
            }

            for (int i = 0; i <= 14; i++)
            {
                var lastPos = puzzles[i].targetPos;
                int randomIndex = Random.Range(0, 14);

                puzzles[i].targetPos = puzzles[randomIndex].targetPos;
                puzzles[randomIndex].targetPos = lastPos;

                var puzzle = puzzles[i];
                puzzles[i] = puzzles[randomIndex];
                puzzles[randomIndex] = puzzle;
            }

            invertion = GetInversions();
            //Debug.Log("shuffle");
        } while (invertion % 2 != 0);
    }

    public int FindIndex(PuzzleScript ps)
    {
        for (int i = 0; i < puzzles.Length; i++)
        {
            if (puzzles[i] != null)
            {
                if (puzzles[i] == ps)
                {
                    return i;
                }
            }
        }

        return -1;
    }

    int GetInversions()
    {
        int inversionsSum = 0;
        for (int i = 0; i < puzzles.Length; i++)
        {
            int thisPuzzleInvertion = 0;
            for (int j = i; j < puzzles.Length; j++)
            {
                if (puzzles[j] != null)
                {
                    if (puzzles[i].number > puzzles[j].number)
                    {
                        thisPuzzleInvertion++;
                    }
                }
            }
            inversionsSum += thisPuzzleInvertion;
        }
        return inversionsSum;
    }
}
