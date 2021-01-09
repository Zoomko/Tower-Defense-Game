using System.Collections;
using System.Collections.Generic;
using TowerDefense.GamePool;
using UnityEngine;

public class Starter : MonoBehaviour
{
    public Spawner Spawner;

    void Start()
    {
        TargetMove.TargetAchivedEvent += TargetMove_TargetAchivedEvent;
        Spawner.SpawnNewObject = (inst, pos, rot) =>
        {
            var obj = PoolFacade.Instance.Take<NavMeshAgetnPoolable>();
            obj.transform.localPosition = pos;
            return obj;
        };
        Spawner.StartSpawn();

    }

    private void TargetMove_TargetAchivedEvent(GameObject obj)
    {
        PoolFacade.Instance.Put(obj);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
