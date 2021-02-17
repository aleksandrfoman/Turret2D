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
        [SerializeField]
        private int _priceToScore = 25;

        private void Start()
        {
          _playerPos = GameObject.FindGameObjectWithTag("Player").transform;  
        }

        private void Update()
        {
            if (!GameController.GAME_OVER)
            {
                Move();
            }
            else
            {
                DestroyEnemy();
            }
               
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
           // GameController.SCORE += _priceToScore;
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
                Debug.Log(_playerPos + "Error");
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