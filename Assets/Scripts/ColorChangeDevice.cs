using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeDevice : MonoBehaviour
{
    private Color red = Color.red;
    private Color green = Color.green;
    private Color blue = Color.blue;
    private Renderer _monitorRenderer;

    private GameObject _lockedDoor;

    void Start(){
        _monitorRenderer = GetComponent<Renderer>();
        _lockedDoor = GameObject.FindWithTag("LockedDoor");
    }
    public void Operate() {
        Color current = _monitorRenderer.material.color;
        if(current == red){
            _monitorRenderer.material.color = blue;
        } else if(current == blue){
            _monitorRenderer.material.color = green;
        } else {
            _monitorRenderer.material.color = red;
        }
        _lockedDoor.SendMessage("CheckCombo", SendMessageOptions.DontRequireReceiver);
    }
}
