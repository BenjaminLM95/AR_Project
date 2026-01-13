using UnityEngine;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems; 

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private ARPlaneManager planeManager; 

    [Header("Spawn System")]
    [SerializeField] private GameObject goPrefab;
    [SerializeField] private float cooldown = 5f;

    private float lastSpawnTime;


    private void OnEnable()
    {
        planeManager.planesChanged += OnPlanesChanged;
    }

    private void OnDisable()
    {
        planeManager.planesChanged -= OnPlanesChanged; 
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
