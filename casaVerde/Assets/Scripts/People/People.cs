using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class People : ScriptableObject
{
    public string nome;
    [TextArea(3,10)]
    public string relato;
    public Sprite rosto;
    public int custo;
    public bool demencia;
}
