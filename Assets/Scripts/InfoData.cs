using UnityEngine;

public class InfoData : MonoBehaviour
{
   [SerializeField] private string info;

    private void Awake()
    {
        if (gameObject.tag != "Info") 
        {
            gameObject.tag = "Info"; 
        }
    }
    public string GetString() 
    {
        return info; 
    }
}
