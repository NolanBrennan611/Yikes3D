using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{
    private float _speed = 3.0f;
    private float _obstacleRange = 5.0f;
    private bool _isAlive;
    [SerializeField] private GameObject _fireballPrefab;
    private GameObject _fireball;

    void Start() {
        _isAlive = true;
    }

    void Update() {
        if(_isAlive){
            transform.Translate(0, 0, _speed * Time.deltaTime);
        }
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit)) {
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.GetComponent<PlayerCharacter>()) {
                if (_fireball == null) {
                    _fireball = Instantiate(_fireballPrefab);
                    _fireball.transform.position =
                    transform.TransformPoint(Vector3.forward * 1.5f);
                    _fireball.transform.rotation = transform.rotation;
                }
            } else if (hit.distance < _obstacleRange) {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }
    }

    public void SetAlive(bool alive){
        _isAlive = alive;
    }
}


