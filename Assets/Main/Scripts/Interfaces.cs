using System;
using UnityEngine;

namespace TowerDefense.Interfaces
{ 
    public interface IPoolable
    {
        GameObject gameObject { get;  }
        Type Type { get; }             
    }
}
