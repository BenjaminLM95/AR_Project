using TMPro;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    public TextMeshProUGUI playerScore;    
    public int score;
    public int currentScore;

    private bool canCount = false; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentScore = 0;
        UpdateScore(); 
    }

    // Update is called once per frame
    void Update()
    {
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
}
