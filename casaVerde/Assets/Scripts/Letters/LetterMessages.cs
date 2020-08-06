using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LetterMessages : ScriptableObject
{
    [TextArea(3,10)]
    public string[] messages;
}
