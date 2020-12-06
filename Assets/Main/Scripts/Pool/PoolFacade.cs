using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TowerDefense.Interfaces;

namespace TowerDefense.GamePool
{
    public class PoolFacade : MonoBehaviour
    {
        //Используется Singleton, т.к. это будет единственный объект на сцене
        //Можно убрать, если делигировать все обязанности какому-то объекту на сцене
        #region Singleton
        private static PoolFacade _instance;
        public static PoolFacade Instance {
            get {
                if (_instance != null)
                    return _instance;
                else
                    throw new NullReferenceException();
            }
        }
        #endregion

        [SerializeField]
        private List<GameObject> _objects;
        private Pool<MonoBehaviour> _pool;

        private void Awake()
        {
            _instance = this;
            _pool = new Pool<MonoBehaviour>(transform, _objects);
            
        }

    }    
}
