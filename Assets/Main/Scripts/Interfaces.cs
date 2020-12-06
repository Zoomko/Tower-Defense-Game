using System;
using UnityEngine;

namespace TowerDefense.Interfaces
{ 
    public interface IPoolable
    {
        Type Type { get; }
        GameObject GetGameObject();             
    }
}
