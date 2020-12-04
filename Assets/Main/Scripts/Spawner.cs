using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<SpawnRule> SpawnRules = new List<SpawnRule>();
    public Func<UnityEngine.Object, Vector3, Quaternion, UnityEngine.Object> SpawnNewObject;

    private Vector3 SpawnPosition; 

    void Start()
    { 
        SpawnPosition = this.transform.position;

        if (SpawnNewObject is null)
            SpawnNewObject = Instantiate;
        
        foreach(var spawnRule in SpawnRules)
        {
            if (spawnRule.SpawnRateSeconds != 0 || spawnRule.CountSpawnObjects <= 0)
                StartCoroutine(Spawn(spawnRule));
        }
    }

    IEnumerator Spawn(SpawnRule spawnRule)
    {
        yield return new WaitForSeconds(spawnRule.SpawnShiftSeconds);
        for(var i = 0; i < spawnRule.CountSpawnObjects; i++)
        {
            yield return new WaitForSeconds(spawnRule.SpawnRateSeconds);
            SpawnNewObject(spawnRule.SpawnObject, SpawnPosition, Quaternion.identity);
        }
    }
}
