using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControlStartSpawn : MonoBehaviour
{
    public Spawner Spawner;

    void Start()
    {
        
    }

    bool SpawnStarted = false;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (Spawner == null) throw new System.ArgumentNullException("Не инициализирован спавнер");
            if (SpawnStarted == false)
            {
                SpawnStarted = true;
                Spawner.StartSpawn();
            }
        }
    }
}
