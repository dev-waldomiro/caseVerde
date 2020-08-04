using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManagerScript : MonoBehaviour
{
    public RectTransform[] panelGroup;
    private Vector2 translation = new Vector2();

    private float changeTime;
    private float delayToChange;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void movePanels () 
    {
        for(int i = 0; i <= panelGroup.Length; i++)
        {
            Debug.Log("hey, im here");
            translation = panelGroup[i].anchoredPosition;
            translation.x += -1200;
            panelGroup[i].DOAnchorPos(translation,1f).SetDelay(0.25f);
        }
    }
}
