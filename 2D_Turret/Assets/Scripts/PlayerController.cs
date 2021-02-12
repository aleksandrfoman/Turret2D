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
        private int _maxHealth;
        private int _currentHealth;
        [SerializeField]
        private HealthBar _healthBar;


        private void Start()
        {
            _currentHealth = _maxHealth;
            _healthBar.SetMaxHealth(_maxHealth);

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


        public void TakeDamage(int value)
        {
            _currentHealth -= value;
            _healthBar.SetHealth(_currentHealth);

            if (_currentHealth <= 0)
            {
                Destroy(gameObject);
                GameController.GAME_OVER = true;
                Debug.Log(GameController.GAME_OVER + "GAME OVER");
            }
        }
    }

}
