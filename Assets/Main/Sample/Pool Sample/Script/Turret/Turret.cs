using UnityEngine;
using TowerDefense.GamePool;

namespace TowerDefense.Sample.Pool
{
    public class Turret : MonoBehaviour
    {
        [SerializeField]
        private Bullet _bullet;
        [SerializeField]
        private Transform gun;
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                print("Fire");
                Shot();
            }
        }
        private void Shot()
        {
            var bullet = PoolFacade.Instance.Take<Bullet>();
            bullet.transform.position = gun.transform.position;
            bullet.StartFlying();
        }
    }
}
