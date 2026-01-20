using UnityEngine;

public class GamestateManager : MonoBehaviour
{
    public enum GameState 
    {
        Menu,
        Pause,
        Gameplay,
        Results
    
    }

    [SerializeField] GameState gameState;
    [SerializeField] GameState previousState; 
    public string gamestateString;

    private UIManager uiManager; 
    private PointManager pointManager;
    private TouchSystem touchSystem; 

    private void Awake()
    {
        uiManager = FindFirstObjectByType<UIManager>();
        pointManager = FindFirstObjectByType<PointManager>();
        touchSystem = FindFirstObjectByType<TouchSystem>(); 

        ChangeStates(GameState.Menu); 
    }
    
    public void ChangeStates(GameState gs) 
    {
        previousState = gameState;
        gameState = gs;
        HandleStateChange(gameState);
        GetGameStateString();
    }

    public void HandleStateChange(GameState gs) 
    {
        switch (gs) 
        {
            case GameState.Menu:
                uiManager.GetToMainMenu();
                Time.timeScale = 0f;
                touchSystem.canTouch = false; 
                break;
            case GameState.Gameplay:
                uiManager.GetToGamePlay();
                Time.timeScale = 1f;
                touchSystem.canTouch = true; 
                break;
            case GameState.Pause:
                uiManager.PauseGame();
                Time.timeScale = 0f;
                touchSystem.canTouch = false;
                break;
            case GameState.Results:
                uiManager.GoToResult();
                Time.timeScale = 0f;
                touchSystem.canTouch = false;
                break; 
            
        }
    }


    public void GetGameStateString() 
    {
        gamestateString = gameState.ToString(); 
    }

    public void GoToGamePlay() 
    {
        ChangeStates(GameState.Gameplay); 
        pointManager.EnableCouting();
    }

    public void GoToResultScreen() 
    {
        ChangeStates(GameState.Results); 
    }

    
}
