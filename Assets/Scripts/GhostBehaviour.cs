using UnityEngine;

public class GhostBehaviour : MonoBehaviour
{
    float floatSpeed = 2f;
    float floatHeight = 0.1f;
    float speed = 3f; 

    Vector3 startPos;
    Vector3 targetPos;

    Transform cameraTransform;

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

        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPos) < 0.05f)
        {
            PickNewTarget();
        }
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
    }

}
