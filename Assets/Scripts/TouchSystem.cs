using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TouchSystem : MonoBehaviour
{
    public GameObject objPopup;

    public ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private float infoDisplayCoolDown;
    private bool canDisplay = true;

    private PointManager pointManager;

    private void Awake()
    {
        pointManager = FindFirstObjectByType<PointManager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        ClickingAction();
        TouchingAction(); 
    }

    private void ClickingAction() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pressed primary button");

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit mHit;

            if (Physics.Raycast(ray, out mHit, 100))
            {
                Debug.Log("Hit");
                Debug.Log(mHit.transform.name + " : " + mHit.transform.tag);

                if (mHit.transform.tag == "Info")
                {                   
                    Vector3 pos = mHit.point;
                    pos.x -= 0.25f;
                    pos.y += 0.25f;
                    pos.z -= 0.25f; 
                    

                    InfoData hitInfoData = mHit.collider.GetComponent<InfoData>();
                    string objInfo = hitInfoData.GetString();
                    Debug.Log(objInfo);

                    TextMeshPro tmp = objPopup.GetComponent<TextMeshPro>();
                    tmp.text = objInfo;

                    Instantiate(objPopup, pos, transform.rotation);
                }

                if (mHit.transform.tag == "Enemy")
                {
                    Destroy(mHit.transform.gameObject);
                    pointManager.IncreaseScore(); 
                }
            }
        }
    }

    private void TouchingAction() 
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Debug.Log("Touch");

            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

            if (touch.phase == TouchPhase.Began) 
            {
                if(Physics.Raycast(ray, out hit, 100)) 
                {
                    Debug.Log("Hit object: " + hit.collider.name);

                    Debug.Log("Hit");
                    Debug.Log(hit.transform.name + " : " + hit.transform.tag);

                    if (hit.transform.tag == "Info")
                    {
                        Vector3 pos = hit.point;                       
                        pos.y += 0.75f;
                        Instantiate(objPopup, pos, transform.rotation);
                    }

                    if (hit.transform.tag == "Enemy")
                    {
                        Destroy(hit.transform.gameObject);
                    }
                }
            }            
                        
        }
    }
}
