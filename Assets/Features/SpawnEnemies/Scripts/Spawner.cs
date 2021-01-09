using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<int> ShiftSecondsForWaveSpawn= new List<int>();
    public List<SpawnWave> SpawnWaves = new List<SpawnWave>();
    public Func<UnityEngine.Object, Vector3, Quaternion, UnityEngine.Object> SpawnNewObject;

    private Vector3 SpawnPosition; 

    void Awake()
    {
        
    }

    public void StartSpawn()
    {
        SpawnPosition = this.transform.position;

        if (SpawnNewObject == null)
            SpawnNewObject = (obj, pos, q) => Instantiate(obj, pos, q, this.transform);

        for (var i = 0; i < SpawnWaves.Count; i++)
        {
            var shiftInSeconds = 0;
            if (ShiftSecondsForWaveSpawn.Count > i)
                shiftInSeconds = ShiftSecondsForWaveSpawn[i];

            var wave = SpawnWaves[i];


            StartCoroutine(
                wave.StartSpawn(
                    SpawnNewObject,
                    shiftInSeconds,
                    SpawnPosition
                ));
        }
    }
}
