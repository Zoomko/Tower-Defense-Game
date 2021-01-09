using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{
    public Spawner Spawner;

    void Start()
    {
        Spawner.StartSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
