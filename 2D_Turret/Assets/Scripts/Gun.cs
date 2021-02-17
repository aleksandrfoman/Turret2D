using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Turret2d
{
    public class Gun : MonoBehaviour
    {
        [SerializeField]
        private GameObject _bulletPrefab;
        [SerializeField]
        private Transform[] _shootPointsPos;

        private float _currentFireTime;
        [SerializeField]
        private float _FireTime;

        private void Start()
        {
            _currentFireTime = _FireTime;
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.W))
            {
                
                if (_currentFireTime <= 0f)
                {
                    _currentFireTime = _FireTime;
                    Shoot(_shootPointsPos);
                }
                
            }
            else
            {
                _currentFireTime -= Time.deltaTime;
            }
        }
        private void Shoot(Transform[] gunsShootPoints)
        {
            foreach (var item in gunsShootPoints)
            {
                Instantiate(_bulletPrefab, item.position, item.rotation);
            }
        }
    }

}
