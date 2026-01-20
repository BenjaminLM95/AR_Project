using UnityEngine;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Linq;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private ARPlaneManager planeManager; 

    [Header("Spawn System")]
    [SerializeField] private GameObject goPrefab;
    [SerializeField] private GameObject ghostType2; 
    [SerializeField] private float cooldown = 5f;

    private float lastSpawnTime;
    private float spawningTimeCount = 0;
    private float enemyTwoSpawnTime = 0; 


    private void OnEnable()
    {
        planeManager.planesChanged += OnPlanesChanged;
    }

    private void OnDisable()
    {
        planeManager.planesChanged -= OnPlanesChanged; 
    }

    private void Start()
    {
        enemyTwoSpawnTime = GettingRandomTime(); 
    }

    private void Update()
    {
        spawningTimeCount += Time.deltaTime; 

        if(spawningTimeCount >= enemyTwoSpawnTime) 
        {
            SpawningEnemyTwo(); 
            spawningTimeCount = 0f;
            enemyTwoSpawnTime = GettingRandomTime();
        }

    }

    private float GettingRandomTime() 
    {
        System.Random rnd = new System.Random();
        int intRnd = rnd.Next(5, 20);
        return (float)intRnd; 
    }

    private void SpawningEnemyTwo() 
    {
        Instantiate(ghostType2, new Vector3(0f, 0f, 0f), Quaternion.identity);
    }

    private void OnPlanesChanged(ARPlanesChangedEventArgs args) 
    {
        foreach(ARPlane plane in args.added) 
        {
            if (plane.alignment != PlaneAlignment.Vertical)
                continue;

            if (Time.time - lastSpawnTime < cooldown)
                return;
            SpawnOnWall(plane); 
            
        }
    }

    private void SpawnOnWall(ARPlane plane) 
    {
        Vector3 position = plane.center;
        Quaternion rotation = Quaternion.LookRotation(-plane.transform.forward, Vector3.up);

        Instantiate(goPrefab, position, rotation);
        lastSpawnTime = Time.time; 
    }
}
