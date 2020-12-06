using System.Collections.Generic;
using UnityEngine;
using System;
using TowerDefense.Interfaces;

namespace TowerDefense.GamePool
{
    public class PoolFacade : MonoBehaviour
    {        
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
        private List<PoolableObject> _objects;
        private Pool _pool;

        private void Awake()
        {
            _instance = this;
            _pool = new Pool(transform, _objects);
        }

        public T Take<T>() where T : MonoBehaviour,IPoolable => _pool.Take<T>();
        public GameObject TakeGameObject<T>() where T : MonoBehaviour, IPoolable => _pool.TakeGameObject<T>();

        public void Put(GameObject GameObject) => _pool.Put(GameObject);
        public void Put(IPoolable IPoolableObject) => _pool.Put(IPoolableObject);

    }    
}
