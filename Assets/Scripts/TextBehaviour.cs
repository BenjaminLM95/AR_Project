using UnityEngine;

public class TextBehaviour : MonoBehaviour
{
    public float textCooldown = 3f;

    private void Start()
    {
        Invoke("SetInactive", textCooldown); 
    }

    public void SetInactive() 
    {
        gameObject.SetActive(false); 
    }
}
