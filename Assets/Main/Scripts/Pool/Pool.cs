using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.Interfaces;

namespace TowerDefense.GamePool
{
    public class Pool<T> where T : MonoBehaviour, IPoolable
    {
        private Dictionary<Type, Queue<IPoolable>> _objectsInPool;
        private Transform _poolFacadeTransform;
        private Pool(Transform poolFacadeTransform)
        {
            _poolFacadeTransform = poolFacadeTransform;
            _objectsInPool = new Dictionary<Type, Queue<IPoolable>>();
        }

        public Pool(Transform poolFacadeTransform, List<GameObject> gameObjects) : this(poolFacadeTransform)
        {
            FillContainer(gameObjects);
        }

        //Main interface
        //-------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------
        public GameObject TakeGameObject<T>()
        {
            var poolableObject = TakeIPoolableObject<T>();
            return poolableObject.GetGameObject();
        }

        public IPoolable TakeIPoolableObject<T>()
        {
            Type typeOfRequestedObject = typeof(T);

            if (HasIPoolableObjectKeyInContainer(typeOfRequestedObject))
            {
                IPoolable foundObject = GetObjectFromContainerByType(typeOfRequestedObject);
                PreparingForGettingFromPool(foundObject);
                return foundObject;
            }
            else
            {
                throw new UnityException("Pool doesn't have this type of object");
            }
        }

        public void Put(GameObject gameObject)
        {
            AddGameObjectInContainer(gameObject);
        }

        public void Put(IPoolable poolableObject)
        {
            AddIPoolableInContainer(poolableObject);
        }
        //-------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------

        private void FillContainer(List<GameObject> gameObjects)
        {
            foreach (var gameObject in gameObjects)
            {
                AddGameObjectInContainer(gameObject);
            }
        }
        private IPoolable GetObjectFromContainerByType(Type type)
        {
            if (IsALittleObjectInSection(type))
            {                
                return CreateNewIPoolableObjectByType(type);
            }
            else
            {
                return _objectsInPool[type].Dequeue();
            }
        }
        private bool IsALittleObjectInSection(Type type)
        {
            if (_objectsInPool[type].Count < 1)
            {
                throw new UnityException("Setion Is Empty");
            }
            if (_objectsInPool[type].Count == 1)
            {
                return true;
            }
            else return false;
        }
        private IPoolable CreateNewIPoolableObjectByType(Type type)
        {
            var lastGameObjectInSection = _objectsInPool[type].Peek();
            var newGameObject = GameObject.Instantiate(lastGameObjectInSection.GetGameObject());
            IPoolable poolableComponent = newGameObject.GetComponent<IPoolable>();
            return poolableComponent;
        }
        private void PreparingForGettingInPool(GameObject gameObject)
        {
            gameObject.SetActive(false);
            gameObject.transform.SetParent(_poolFacadeTransform);
        }
        private bool HasIPoolableObjectKeyInContainer(Type type)
        {            
            if (_objectsInPool.ContainsKey(type))
                return true;
            else return false;
        }
        private void PreparingForGettingFromPool(IPoolable poolable)
        {
            var gameObject = poolable.GetGameObject();
            gameObject.SetActive(true);
            gameObject.transform.SetParent(null);
        }

        private void AddIPoolableInContainer(IPoolable poolableObject)
        {           
            Type type = poolableObject.GetType();

            PreparingForGettingInPool(poolableObject.GetGameObject());

            AddIPoolableObjectInContainerByTypeWithoutPreparing(type, poolableObject);
        }

        private void AddGameObjectInContainer(GameObject gameObject)
        {
            PreparingForGettingInPool(gameObject);

            IPoolable castedObject = CastInIPoolable(gameObject);
            Type type = castedObject.GetType();

            AddIPoolableObjectInContainerByTypeWithoutPreparing(type, castedObject);
        }
        private void AddIPoolableObjectInContainerByTypeWithoutPreparing(Type type, IPoolable poolableObject)
        {
            if(_objectsInPool.ContainsKey(type))
            {
                _objectsInPool[type].Enqueue(poolableObject);
            }
            else
            {
                _objectsInPool.Add(type, new Queue<IPoolable>());
            }
        }
        private IPoolable CastInIPoolable(GameObject gameObject)
        {
            IPoolable poolableObject;
            if (gameObject.TryGetComponent<IPoolable>(out poolableObject))
                return poolableObject;
            else
                throw new UnityException("Argument doesn't contain IPoolable interface");
        }
    }
}
