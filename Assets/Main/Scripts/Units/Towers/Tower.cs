using System;
using System.Collections;
using System.Collections.Generic;
using TowerDefense.Interfaces;
using TowerDefense.ScriptableObjects.Towers;
using UnityEngine;

namespace TowerDefense.Units.Tower
{
    public class Tower : MonoBehaviour,IPoolable
    {
        [SerializeField]
        private TowerInfo _info;
        public TowerInfo Info { get => _info; 
            set 
            { _info = value;
              InitTower();
            } 
        }

        public Type Type => typeof(Tower);

        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();            
            if (_info != null)
                InitTower();
        }

        private void InitTower()
        {
            _spriteRenderer.sprite = _info.Image;
        }
        
    }
}
