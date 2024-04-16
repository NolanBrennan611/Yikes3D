using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        print("This is the end! I ran out of time for more detail");
    }
}
