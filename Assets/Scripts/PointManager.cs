using TMPro;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    public TextMeshProUGUI playerScore;
    public int score;
    public int currentScore; 

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
        currentScore++; 
    }
}
