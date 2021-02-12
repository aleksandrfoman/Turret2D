using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Turret2d
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private Vector3 _vectorEuler;
        [SerializeField]
        private GameObject _projectilePrefab;
        [SerializeField]
        private Transform _shootPoint;
        [SerializeField]
        private float _maxHealth;
        private float _currentHealth;
        [SerializeField]
        private Image _healthBar;


        private void Start()
        {
            _currentHealth = _maxHealth;
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.Rotate(_vectorEuler);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                transform.Rotate(-_vectorEuler);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            Instantiate(_projectilePrefab, _shootPoint.position,_shootPoint.rotation);
        }

        private void UpdateHealthBar()
        {
           // _healthBar.fillAmount = _health; 
        }

        public void TakeDamage(int value)
        {
            _currentHealth -= value;
            UpdateHealthBar();

            if (_currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

}
