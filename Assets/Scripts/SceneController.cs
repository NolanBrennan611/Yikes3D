using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    private GameObject _enemy;
    private int count = 0; 
    [SerializeField] private int _maxSpawn;
    [SerializeField] private int _spawnX;
    [SerializeField] private int _spawnZ;
    void Update() {
        if (count < _maxSpawn) {
            _enemy = Instantiate(_enemyPrefab);
            _enemy.transform.position = new Vector3(_spawnX, 1, _spawnZ);
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);
            count++;
        }
    }

}
