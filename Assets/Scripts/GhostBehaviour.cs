using UnityEngine;

public class GhostBehaviour : MonoBehaviour
{
    float floatSpeed = 2f;
    float floatHeight = 0.1f;
    float speed = 3f;
    float distanceSpeed = 0.05f; 

    Vector3 startPos;
    Vector3 targetPos;

    [SerializeField] Transform cameraTransform;
    public float distanceFromCamera; 

    public GameObject soulAfterDeath; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {       
        startPos = transform.localPosition;
        cameraTransform = Camera.main.transform;
        targetPos = cameraTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.localPosition = new Vector3(startPos.x, newY, startPos.z);
        /*
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPos) < 0.05f)
        {
            PickNewTarget();
        }*/

        

    }

    private void FixedUpdate()
    {/*
        if (Vector3.Distance(transform.position, cameraTransform.position) < 3f)
        {
            Vector3 disMov = (transform.position - cameraTransform.position).normalized; 
            distanceFromCamera = Vector3.Distance(transform.position, cameraTransform.position);
            float mvX = transform.position.x + disMov.x * distanceSpeed;
            float mvZ = transform.position.x + disMov.z * distanceSpeed;            
            transform.localPosition = new Vector3(mvX, transform.position.y, mvZ);
        } */
    }


    void PickNewTarget()
    {
        Vector2 randomCircle = Random.insideUnitCircle * 0.5f;
        targetPos = startPos + new Vector3(randomCircle.x, 0, randomCircle.y);
    }


    private void OnDestroy()
    {
        Vector3 currentPos = transform.position; 
        Instantiate(soulAfterDeath, currentPos, Quaternion.identity);
        SoundManager.instance.PlaySoundFXClip("GhostVanishClip"); 
    }

}
