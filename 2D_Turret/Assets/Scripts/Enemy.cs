using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Turret2d
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        private int _health = 100;
        private Transform _playerPos;
        [SerializeField]
        private float _moveSpeed;
        [SerializeField]
        private int _damage = 15;

        private void Start()
        {
          _playerPos = GameObject.FindGameObjectWithTag("Player").transform;  
        }

        private void Update()
        {
            Move();
        }

        public void TakeDamage(int value)
        {
            _health -= value;
            if (_health <= 0)
            {
                DestroyEnemy();
            }
        }

        private void DestroyEnemy()
        {
            Destroy(gameObject);
        }

        private void Move()
        {
            if (_playerPos != null)
            {
                gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, _playerPos.position, _moveSpeed * Time.deltaTime);
                
            }
            else
            {
                DestroyEnemy();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                collision.GetComponent<PlayerController>().TakeDamage(_damage);
                Destroy(gameObject);
            }


        }
    }
}