using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWave : MonoBehaviour
{
    public List<SpawnRule> SpawnRules = new List<SpawnRule>();

    public IEnumerator StartSpawn(
        Func<UnityEngine.Object, Vector3, Quaternion, UnityEngine.Object> SpawnNewObject,
        float shiftSpawnInSeconds,
        Vector3 spawnPosition
        )
    {
        yield return new WaitForSeconds(shiftSpawnInSeconds);

        foreach (var spawnRule in SpawnRules)
        {
            if (spawnRule.SpawnRateSeconds != 0 || spawnRule.CountSpawnObjects <= 0)
                StartCoroutine(spawnRule.Spawn(SpawnNewObject, spawnPosition));
        }
    }
}
