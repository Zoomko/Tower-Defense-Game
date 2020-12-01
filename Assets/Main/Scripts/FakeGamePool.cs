using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeGamePool : MonoBehaviour, IGamePool<GameObject>
{
    public GameObject CloneParrent;

    public GameObject Spawn(Vector3 position, Quaternion quaternion)
    {
        return Instantiate(CloneParrent, position, quaternion);
    }
}
