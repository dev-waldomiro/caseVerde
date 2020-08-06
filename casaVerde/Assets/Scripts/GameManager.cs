using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private RentController rentController;
    private LetterManager letterManager;
    private UIManager uiManager;
    private LevelLoader levelLoader;
    private AudioManager audioManager;

    [SerializeField] private int rentRoof = 5;
    [SerializeField] private int filesRoof = 1;
    private int cost;
    private int wrongInterns;
    private int filesSeen;
    private bool gameOver=true;
    private bool gameWon=false;
    
    void Awake()
    {
        rentController = GameObject.Find("RentCounter").GetComponent<RentController>();
        letterManager = GameObject.Find("LetterManager").GetComponent<LetterManager>();
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        rentController.rentRoof = rentRoof;
        
        gameOver=true;
        cost = 0;
        wrongInterns = 0;
        filesSeen = 0;
    }

    private void Update() 
    {
        cost = rentController.costGain;

        if(wrongInterns >= 3) 
        {
            letterManager.SetInternLetter();    
            letterManager.DisplayLetter();
            uiManager.BringLetterDown(true);
            audioManager.Play("LetterReached");
            gameOver = false;
            wrongInterns--;
        }

        if(filesSeen == filesRoof)
        {
            if(cost < rentRoof)
            {
                Debug.Log("time to pay the rent");
                letterManager.SetRentLetter();    
                letterManager.DisplayLetter();
                uiManager.BringLetterDown(false);
                audioManager.Play("LetterReached");
                gameOver=false;
                filesSeen--;
            } else
            {
                letterManager.SetFinalLetter();    
                letterManager.DisplayLetter();
                uiManager.BringLetterDown(false);
                audioManager.Play("LetterReached");
                gameOver=false;
                filesSeen--;
                gameWon = true;
                Debug.Log("final said hey");
            }   
        }

        if(letterManager.lastIndex && gameOver)
        {
            letterManager.lastIndex = false;
            uiManager.BringLetterUp();
            audioManager.Play("LetterReached");
        } else if(letterManager.lastIndex && gameWon)
        {
            levelLoader.LoadNextLevel(false);
        } else if(letterManager.lastIndex && !gameOver)
        {
            levelLoader.LoadNextLevel(true);
        }
        
    }


    public void SetWrongInterns ()
    {
        wrongInterns++;
    }

    public IEnumerator SetFilesSeen ()
    {
        audioManager.Play("ButtonPress");
        yield return new WaitForSeconds(0.5f);
        filesSeen++;
        uiManager.MovePanels(gameOver);
        if(gameOver) audioManager.Play("FileReached");
        Debug.Log(filesSeen);
    }

    public int GetRentRoof ()
    {
        return rentRoof;
    }

    public int GetFilesRoof ()
    {
        return filesRoof;
    }

}
