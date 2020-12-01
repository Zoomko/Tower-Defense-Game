using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
   // public Transform SpawnPosition; 
    public List<SpawnRule> SpawnRules = new List<SpawnRule>();

    public IGamePool<GameObject> GamePool;

    void Start()
    {
        // Каким-то нормальным образом надо сделать передачу GamePool
        // GetComponent<IGamePool<GameObject>>() не работает, хотя на сцене есть объект реализующий этот интерфейс
        // Так же интерфейс не отображается для интерактивной передачи реализации интерфейса в юнити (путем перетаскивания которое)
        
        foreach(var spawnRule in SpawnRules)
        {
            GamePool = new FakeGamePool()
            {
                CloneParrent = spawnRule.gameObject
            };
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
            GamePool.Spawn(this.transform.position, Quaternion.identity);
        }
    }
}
