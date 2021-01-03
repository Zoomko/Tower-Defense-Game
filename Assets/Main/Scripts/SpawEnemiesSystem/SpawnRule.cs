using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRule : MonoBehaviour
{
    public GameObject SpawnObject;
    public float SpawnRateSeconds;
    public float SpawnShiftSeconds;
    public int CountSpawnObjects;

    public IEnumerator Spawn(
        Func<UnityEngine.Object, Vector3, Quaternion, UnityEngine.Object> SpawnNewObject,
        Vector3 SpawnPosition)
    {
        yield return new WaitForSeconds(SpawnShiftSeconds);
        for (var i = 0; i < CountSpawnObjects; i++)
        {
            yield return new WaitForSeconds(SpawnRateSeconds);
            SpawnNewObject(SpawnObject, SpawnPosition, Quaternion.identity);
        }
    }
}
