using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBonus : MonoBehaviour
{
    public GameObject[] spawnObjects;
    public Transform[] spawnLocations;

    void Start()
    {
        RespawnBonus();
    }

    public void RespawnBonus()
    {
        Instantiate(spawnObjects[Random.Range(0, spawnObjects.Length)], spawnLocations[Random.Range(0, spawnLocations.Length)]);        
    }

    public void DestroyBonus() {
        GameObject[] taggedObjects = GameObject. FindGameObjectsWithTag("Pickup");
        foreach (GameObject pickup in taggedObjects) {
            Destroy(pickup);
        }
    }
}
