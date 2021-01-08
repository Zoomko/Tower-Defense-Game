using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.ScriptableObjects.Towers
{
    [CreateAssetMenu(fileName = "TowerInfo", menuName = "TowerDefense/Tower")]
    public class TowerInfo : ScriptableObject
    {
        [SerializeField]
        private Sprite _image;
        [SerializeField]
        private Sprite _bulletImage;
        [SerializeField]
        private float _range;
        [SerializeField]
        private float _attackSpeed;
        [SerializeField]
        private float _damage;

        public Sprite Image { get => _image;}
        public Sprite BulletImage { get => _bulletImage; }
        public float Range { get => _range; }
        public float AttackSpeed { get => _attackSpeed; }
        public float Damage { get => _damage;}
    }
}
