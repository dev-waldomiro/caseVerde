using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetScriptableObject : MonoBehaviour
{
    public People scrObject;

    public Image rosto;
    public TextMeshProUGUI nome;
    public TextMeshProUGUI relato;
    public TextMeshProUGUI custo;

    void Awake()
    {
        rosto.sprite = scrObject.rosto;
        nome.SetText(scrObject.nome);
        relato.SetText(scrObject.relato);
        custo.SetText("x" + scrObject.custo.ToString());
    }

    public void giveMoney ()
    {
        GameObject.Find("RentCounter").GetComponent<RentController>().getRent(scrObject.custo);
    }

    public void setInterntCounter ()
    {
        if(!scrObject.demencia) GameObject.Find("GameManager").GetComponent<GameManager>().SetWrongInterns();
    }

    public void SetFileRead ()
    {
        StartCoroutine(GameObject.Find("GameManager").GetComponent<GameManager>().SetFilesSeen());
    }

}
