using UnityEngine;


public class MovingCubes : MonoBehaviour
{
    private Vector3 initialPos;
    [SerializeField] private float radius; 

    private void Awake()
    {
        radius = ChangingRadius();          
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

    public int ChangingRadius() 
    {
        System.Random rnd = new System.Random();
        int rndNum = rnd.Next(1, 8);
        return rndNum; 
    }

}
