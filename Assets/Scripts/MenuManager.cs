using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void LoadGame() {
        SceneManager.LoadSceneAsync( "Scene1", LoadSceneMode.Additive );
    }
}
