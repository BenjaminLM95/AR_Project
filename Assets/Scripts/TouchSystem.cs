using UnityEngine;

public class TouchSystem : MonoBehaviour
{
    public GameObject objPopup;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Debug.Log("Pressed primary button");

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit; 

            if(Physics.Raycast(ray, out hit, 100)) 
            {
                Debug.Log("Hit");
                Debug.Log(hit.transform.name + " : " + hit.transform.tag); 

                if(hit.transform.tag == "Info") 
                {
                    Vector3 pos = hit.point;
                    pos.z += 0.25f;
                    pos.y += 0.25f;
                    Instantiate(objPopup, pos, transform.rotation); 
                }

                if(hit.transform.tag == "Enemy") 
                {
                    Destroy(hit.transform.gameObject); 
                }
            }
        }
    }
}
