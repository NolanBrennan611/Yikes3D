using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorGuy : MonoBehaviour
{
    private GameObject _dialogue;
    private GameObject _lockedDoor;
    void Start() {
        _dialogue = GameObject.Find("DialogueBox");
        _dialogue.SetActive(false);
        _lockedDoor = GameObject.Find("LockedDoor");
    }

    void Operate(){
        _dialogue.SetActive(true);
        _dialogue.GetComponent<Dialogue>().StartDialogue();
        _lockedDoor.SendMessage("Activate");
    }
}
