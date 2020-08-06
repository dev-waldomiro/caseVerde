using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public List<RectTransform> panelList;
    public RectTransform letterReference;
    private Vector2 translation = new Vector2();
    private GameManager gameManager;
    [SerializeField] private float changeTime = 1f;
    [SerializeField] private float delayToChange = 0.5f;
    private int currentIndex;

    void Awake()
    {
        currentIndex = -1;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void MovePanels (bool canMove) 
    {
        if(canMove)
        {
            foreach (RectTransform panel in panelList)
            {
                translation = panel.anchoredPosition;
                translation.x += -904.0203f;
                panel.DOAnchorPos(translation, changeTime);
                //.SetDelay(delayToChange)
            }
            currentIndex++;
        }

        
        
    }

    public void BringLetterUp ()
    {
        letterReference.DOAnchorPos(new Vector2(0,600), changeTime);
        MovePanels(true);
    }

    public void BringLetterDown (bool isRentTime)
    {
        if(isRentTime) currentIndex += 1;
        Debug.Log(currentIndex.ToString());
        translation = panelList.ElementAtOrDefault(currentIndex-1).anchoredPosition;
        translation.x += -904.0203f;
        panelList.ElementAtOrDefault(currentIndex-1).DOAnchorPos(translation, changeTime).SetDelay(delayToChange);
        letterReference.DOAnchorPos(new Vector2(0,-30), changeTime).SetDelay(delayToChange);
    }
}
