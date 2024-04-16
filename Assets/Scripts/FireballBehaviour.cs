using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballBehaviour : MonoBehaviour
{
    [SerializeField] private float _speed = 10.0f;
    [SerializeField] private int _damage = 1;
    void Update() {
        transform.Translate(0, 0, _speed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other) {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if (player != null) {
            player.AdjustHitPoints(-_damage);
        }
        Destroy(this.gameObject);
    }
}
