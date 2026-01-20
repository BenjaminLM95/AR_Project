using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GamestateManager gamestateManager;
    [SerializeField] private PointManager pointManager; 

    private void Awake()
    {
        gamestateManager = FindFirstObjectByType<GamestateManager>();
        pointManager = FindFirstObjectByType<PointManager>(); 
    }

    public ARSession arSession;

    public void ResetAR()
    {
        StartCoroutine(ResetSession());
        RestartGame();
    }

    IEnumerator ResetSession()
    {
        // Disable session
        arSession.enabled = false;
        yield return null;

        // Enable session again
        arSession.enabled = true;
    } 

    public void StartGame() 
    {
        gamestateManager.GoToGamePlay(); 
    }

    public void RestartGame() 
    {
        gamestateManager.GoToGamePlay();
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void ResetLevel() 
    {
        gamestateManager.GoToGamePlay();
        pointManager.ResetLevelStats(); 
    }

    public void ResultScreen() 
    {
        gamestateManager.GoToResultScreen(); 
    }

    public void PausingGame() 
    {
        gamestateManager.ChangeStates(GamestateManager.GameState.Pause); 
    }

    public void ExitGame() 
    {
        Application.Quit(); 
    }
}
