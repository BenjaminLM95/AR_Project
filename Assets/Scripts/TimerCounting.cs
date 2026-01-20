using UnityEngine;
using TMPro;


public class TimerCounting : MonoBehaviour
{
    public float timeMax = 180f; // 3 minutes
    public float timeRemaining;     
    public bool timerIsRunning = true;

    private PointManager pointManager;
    public TextMeshProUGUI timerText;

    private int minutes;
    private int seconds; 
    

    private void Awake()
    {
        if(pointManager == null) 
        {
            pointManager = FindFirstObjectByType<PointManager>();
        }

        timeRemaining = timeMax; 
    }

    void Update()
    {
        if(timerText == null) 
        {
            timerText = GameObject.Find("TimerText").GetComponent<TextMeshProUGUI>();
            
        }


        if (!timerIsRunning)
            return;

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            ShowTimeOnScreen(); 
        }
        else
        {
            timerText.text = "Time's up"; 
            timeRemaining = 0;
            timerIsRunning = false;
            TimerEnded();
        }
    }

    void TimerEnded()
    {
        Debug.Log("Time's up!");
        pointManager.DisableCounting();
        pointManager.TimesUp(); 
        // End game, show results, etc.
    }


    public void ResetTimer() 
    {
        timeRemaining = timeMax;
        ShowTimeOnScreen();
        timerIsRunning = true; 
        Debug.Log("Reset Time" + timeRemaining); 
    }

    public void ShowTimeOnScreen() 
    {
        minutes = Mathf.FloorToInt(timeRemaining / 60);
        seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

}
