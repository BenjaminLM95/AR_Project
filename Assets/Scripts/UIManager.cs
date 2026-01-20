using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject gameplayUI;
    public GameObject pauseUI;
    public GameObject resultUI; 
    

    public void GetToMainMenu() 
    {
        DisactivateAllUI();
        menuUI.gameObject.SetActive(true);
    }

    public void GetToGamePlay() 
    {
        DisactivateAllUI();
        gameplayUI.gameObject.SetActive(true); 
    }

    public void PauseGame() 
    {
        DisactivateAllUI();
        pauseUI.gameObject.SetActive(true); 
    }

    public void GoToResult() 
    {
        DisactivateAllUI();
        resultUI.gameObject.SetActive(true); 
    }

    private void DisactivateAllUI() 
    {
        menuUI.gameObject.SetActive(false);
        gameplayUI.gameObject.SetActive(false);
        pauseUI.gameObject.SetActive(false);
        resultUI.gameObject.SetActive(false); 
    }


}
