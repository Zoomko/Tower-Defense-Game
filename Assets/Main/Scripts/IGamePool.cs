using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGamePool<T>
{
    T Spawn(Vector3 position, Quaternion quaternion);
}
