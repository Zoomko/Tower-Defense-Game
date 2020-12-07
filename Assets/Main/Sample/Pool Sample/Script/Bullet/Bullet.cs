using System;
using System.Collections;
using TowerDefense.Interfaces;
using UnityEngine;
using TowerDefense.GamePool;

namespace TowerDefense.Sample.Pool
{
    public class Bullet : MonoBehaviour, IPoolable
    {
        [SerializeField]
        private float _speed;
        [SerializeField]
        private float _existingTime;

        public Type Type => this.GetType();

        public void StartFlying()
        {
            StartCoroutine(Fly());
        }
        public IEnumerator Fly()
        {
            float time = 0;
            while(time<_existingTime)
            {
                time += Time.deltaTime;
                transform.position += transform.up * _speed * Time.deltaTime;
                yield return null;
            }

            PoolFacade.Instance.Put(this);
        }
    } 
}
