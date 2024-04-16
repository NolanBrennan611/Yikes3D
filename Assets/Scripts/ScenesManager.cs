using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ScenesManager : MonoBehaviour
{
    public void QuitGame(){
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    
    public void Update(){
        if(Input.GetKey(KeyCode.Escape)){
            QuitGame();
        }
    }
}
