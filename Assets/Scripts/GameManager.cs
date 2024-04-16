using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _sharedInstance;
    private int _health = 5;

    public static GameManager SharedInstance{
        get {
            return _sharedInstance; 
        }
    }

    public int Health {
        get {
            return _health;
        }
        set {
            _health = value;
        }
    }

    void Awake() {
        if(_sharedInstance == null) {
            DontDestroyOnLoad(gameObject);
            _sharedInstance = this;
        } else if (_sharedInstance != this) {
            Destroy(gameObject);
        }
    }
}
