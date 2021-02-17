using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Turret2d
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField]
        private float _speed;
        [SerializeField]
        private int _damage;

        private Rigidbody2D _rigidbody2D;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
        private void FixedUpdate()
        {
            Move();
        }

        public void Move()
        {
            _rigidbody2D.velocity = transform.right * _speed;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Enemy"))
            {
                Enemy enemy = collision.GetComponent<Enemy>();
                enemy.TakeDamage(_damage);
              
            }
            else if (collision.CompareTag("Wall"))
            {
                Destroy(gameObject);
            }

        }
    }

}
