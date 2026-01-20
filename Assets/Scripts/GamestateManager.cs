using UnityEngine;

public class GamestateManager : MonoBehaviour
{
    public enum GameState 
    {
        Menu,
        Pause,
        Gameplay
    
    }

    [SerializeField] GameState gameState;
    [SerializeField] GameState previousState; 
    public string gamestateString;

    private UIManager uiManager; 
    private PointManager pointManager;

    private void Awake()
    {
        uiManager = FindFirstObjectByType<UIManager>();
        pointManager = FindFirstObjectByType<PointManager>();   

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
                break;
            case GameState.Gameplay:
                uiManager.GetToGamePlay();
                Time.timeScale = 1f;
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

    
}
