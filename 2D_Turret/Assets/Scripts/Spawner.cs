using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Turret2d
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField]
        private Transform[] _spawnPoints;
        [SerializeField]
        private GameObject[] _enemys;

        private float _currentSpawnTime;
        [SerializeField]
        private float _spawnTime;

        private void Start()
        {
            _currentSpawnTime = _spawnTime;
        }

        private void Update()
        {
            if (_currentSpawnTime <= 0f)
            {
                _currentSpawnTime = _spawnTime;
                SpawnEnemy();
            }
            else
            {
                _currentSpawnTime -= Time.deltaTime;
            }
        }

        private void SpawnEnemy()
        {
            int rndSpawn = Random.Range(0, _spawnPoints.Length);
            int rndEnemy = Random.Range(0, _enemys.Length);

            GameObject enemy = Instantiate(_enemys[rndEnemy], _spawnPoints[rndSpawn].position, _spawnPoints[rndSpawn].rotation);

        }
    }
}
