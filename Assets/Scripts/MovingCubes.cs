using UnityEngine;
using System; 

public class MovingCubes : MonoBehaviour
{
    private Vector3 initialPos;
    private float radius = 7; 

    private void Awake()
    {
        initialPos = transform.position;
    }    

    private void FixedUpdate()
    {
        CalculatePosition();
    }


    private void CalculatePosition() 
    {
        float posX = Mathf.Cos(Time.time) * radius;
        float posZ = Mathf.Sin(Time.time) * radius;

        transform.position = new Vector3(posX, transform.position.y, posZ); 
    }

}
