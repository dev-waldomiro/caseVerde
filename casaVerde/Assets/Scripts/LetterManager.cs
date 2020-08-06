using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class LetterManager : MonoBehaviour
{
    public LetterMessages startLetter, internLetter, rentLetter, finalLetter;
    public TextMeshProUGUI content;
    private LetterMessages rightLetter;
    private List<string> messages;
    private int currentIndex;
    [HideInInspector] public bool lastIndex;

    void Awake() 
    {
        currentIndex = 0;
        lastIndex = false;
        rightLetter = startLetter;
        messages = new List<string>();
        DisplayLetter();
    }

    public void DisplayLetter ()
    {
        currentIndex = 0;
        lastIndex = false;
        messages.Clear();
        foreach (string message in rightLetter.messages)
        {
            messages.Add(message);
        }
        content.SetText(messages.ElementAt(currentIndex));
    }
    
    public void NextPage ()
    {
        if(messages.ElementAtOrDefault(currentIndex+1) != null)
        {
            currentIndex++;
            content.SetText(messages.ElementAt(currentIndex));
        }  
        else
        {
            Debug.Log("im here");
            lastIndex = true;
        } 
    }

    public void PreviousPage ()
    {
        if(messages.ElementAtOrDefault(currentIndex-1) != null)
        {
            currentIndex--;
            content.SetText(messages.ElementAt(currentIndex));
        }
    }

    public void SetInternLetter ()
    {
        rightLetter = internLetter;
    }

    public void SetRentLetter ()
    {
        rightLetter = rentLetter;
    }
    public void SetFinalLetter ()
    {
        rightLetter = finalLetter;
    }
}
