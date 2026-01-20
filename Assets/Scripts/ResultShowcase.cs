using UnityEngine;
using TMPro; 

public class ResultShowcase : MonoBehaviour
{
    public TextMeshProUGUI resultScoreText;
    public int showingScore = 0;
    public PointManager pointManager; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pointManager = FindFirstObjectByType<PointManager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(showingScore != pointManager.finalScore) 
        {
            showingScore = pointManager.finalScore;
            resultScoreText.text = "Score: " + showingScore; 
        }
    }
}
