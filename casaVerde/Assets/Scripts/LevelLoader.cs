using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 2.3f;
    public TextMeshProUGUI date;

    void Awake()
    {
        ChangeDate(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel (bool goMenu)
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        if(SceneManager.GetActiveScene().buildIndex + 1 > 5) 
            StartCoroutine(LoadLevel(0));
        if(goMenu) SceneManager.LoadScene(0);
    }

    IEnumerator LoadLevel (int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }

    void ChangeDate (int levelIndex)
    {
        switch (levelIndex)
        {
            case 1:
                date.SetText("Itaguaí\n1886, April");
                break;
            case 2:
                date.SetText("Itaguaí\n1886, May");
                break;
            case 3:
                date.SetText("Itaguaí\n1886, June");
                break;
            case 4: 
                date.SetText("Itaguaí\n1886, July");
                break;
            case 5:
                date.SetText("Itaguaí\n1886, August");
                break;
        }
    }
}
