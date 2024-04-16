using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathzone : MonoBehaviour
{
    void OnTriggerEnter(Collider collision) {
        GameObject.FindWithTag("Player").GetComponent<PlayerCharacter>().AdjustHitPoints(-10);
    }
}
