using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RentController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI rentText;
    private GameManager gameManager;
    [HideInInspector] public int rentRoof;
    [HideInInspector] public int costGain;

    
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rentRoof = gameManager.GetRentRoof();
        rentText = GetComponent<TextMeshProUGUI>();
        rentText.SetText("Rent:\n" + costGain.ToString() + "/" + rentRoof.ToString());
    }

    public void getRent (int custo)
    {
        costGain += custo;
        rentText.SetText("Rent:\n" + costGain.ToString() + "/" + rentRoof.ToString());
    }
}
