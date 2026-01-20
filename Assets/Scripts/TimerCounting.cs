using UnityEngine;
using TMPro;

public class TimerCounting : MonoBehaviour
{
    public float timeRemaining = 180f; // 3 minutes
    public bool timerIsRunning = true;

    private PointManager pointManager;
    public TextMeshProUGUI timerText; 

    private void Awake()
    {
        if(pointManager == null) 
        {
            pointManager = FindFirstObjectByType<PointManager>();
        }
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
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);
            timerText.text = $"{minutes:00}:{seconds:00}";
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
        // End game, show results, etc.
    }
}
