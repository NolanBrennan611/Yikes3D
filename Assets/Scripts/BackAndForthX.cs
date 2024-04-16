using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BackAndForthX : MonoBehaviour {
    [SerializeField] private float _speed = 3.0f;
    [SerializeField] private float _maxX = 10.0f;
    [SerializeField] private float _minX = -10.0f;
    private int _direction = 1;
    void Update() {
        transform.Translate(_direction * _speed * Time.deltaTime, 0, 0);
        bool bounced = false;
        if (transform.position.x > _maxX || transform.position.x < _minX) {
            _direction = -_direction;
            bounced = true;
        }
        if (bounced) {
            transform.Translate(0, 0, _direction * _speed * Time.deltaTime);
        }
    }
}

