using TMPro;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    public TextMeshProUGUI playerScore;    
    public int score;
    public int currentScore;

    private bool canCount = false;

    private LevelManager levelManager;
    [SerializeField] private TimerCounting timerCounting;
    [SerializeField] private GamestateManager gameStateManager; 

    private void Awake()
    {
        levelManager = FindFirstObjectByType<LevelManager>();
        gameStateManager = FindFirstObjectByType<GamestateManager>(); 
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentScore = 0;
        UpdateScore(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(gameStateManager.gamestateString == "Gameplay") 
        {
            if (timerCounting == null)
            {
                timerCounting = FindFirstObjectByType<TimerCounting>();
            }
        }


        if(score != currentScore) 
        {
            UpdateScore(); 
        }
    }

    private void UpdateScore() 
    {
        score = currentScore;
        playerScore.text = "Score: " + score; 
    }

    public void IncreaseScore() 
    {
        if (canCount)
        {
            currentScore++;
        }
    }

    public void EnableCouting() 
    {
        canCount = true;
    }

    public void DisableCounting() 
    {  
        canCount = false; 
    }

    public void TimesUp() 
    {
        levelManager.ResultScreen(); 
    }

    public void ResetTimer() 
    {
        if(timerCounting == null) 
        {
            timerCounting = FindFirstObjectByType<TimerCounting>(); 
        }

        timerCounting.ResetTimer(); 
    }

    public void ResetLevelStats() 
    {
        ResetTimer();
        currentScore = 0; 
    }

}
