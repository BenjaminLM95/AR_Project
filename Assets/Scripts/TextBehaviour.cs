using UnityEngine;

public class TextBehaviour : MonoBehaviour
{
    private void Start()
    {
        Invoke("SetInactive", 3f); 
    }

    public void SetInactive() 
    {
        gameObject.SetActive(false); 
    }
}
