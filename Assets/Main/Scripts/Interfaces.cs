using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Interfaces
{ 
    public interface IPoolable
    {
        Type Type { get; }
        GameObject GetGameObject();
        MonoBehaviour GetMonoBehaviour();
    }
}
