using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject gameplayUI;
    public GameObject pauseUI; 
    

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

    private void DisactivateAllUI() 
    {
        menuUI.gameObject.SetActive(false);
        gameplayUI.gameObject.SetActive(false);
        pauseUI.gameObject.SetActive(false); 
    }


}
