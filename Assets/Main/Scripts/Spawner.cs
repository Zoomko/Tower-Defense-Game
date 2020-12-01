using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform SpawnPosition;
    public GameObject SpawnObject;
    public float SpawnRate;
    public int CountSpawnObjects;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        for(var i = 0; i < CountSpawnObjects; i++)
        {
            yield return new WaitForSeconds(SpawnRate);
            Instantiate(SpawnObject, SpawnPosition.position, Quaternion.identity);
        }
    }
}
