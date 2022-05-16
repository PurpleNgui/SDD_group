using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    public Image Wiki;
    public Image mainch;

    public bool IsPause;


    private int index;
    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
        mainch.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);

        }
    }
    void NextLine()
    {
        //Wiki.enabled = false;
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
            ChangeRoles();
            //if (index == 2)
            //{
            //    Wiki.enabled = true;
            //}
        }
        else
        {
            Wiki.enabled = false;
            mainch.enabled = false;
            gameObject.SetActive(false);
        }

    }

    void ChangeRoles()
    {
        switch (index)
        {
            case 0:
            case 2:
            case 4:
            case 5:
            case 7:
            case 9:
            case 11:
            case 13:
            case 15:
            case 17:
            case 18:
            case 20:
            case 21:
                Wiki.enabled = true;
                mainch.enabled = false;
                break;

            case 1:
            case 3:
            case 6:
            case 8:
            case 10:
            case 12:
            case 14:
            case 16:
            case 19:
                Wiki.enabled = false;
                mainch.enabled = true;
                break;

            default:
                Wiki.enabled = false;
                mainch.enabled = false;
                break;

        }
    }

}
