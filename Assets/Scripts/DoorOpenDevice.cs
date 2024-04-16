using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenDevice : MonoBehaviour
{
    [SerializeField] Vector3 _dPos;
    
    [SerializeField] bool _isLocked;
    private bool _isOpen;

    private GameObject _monitorOne;
    private GameObject _monitorTwo;
    private GameObject _monitorThree;

    void Start(){
        _monitorOne = GameObject.Find("MonitorOne");
        _monitorTwo = GameObject.Find("MonitorTwo");
        _monitorThree = GameObject.Find("MonitorThree");
    }

    public void Operate() {
        if(!_isLocked){
            if (_isOpen) {
                Vector3 pos = transform.position - _dPos;
                transform.position = pos;
            } else {
                Vector3 pos = transform.position + _dPos;
                transform.position = pos;
            }
            _isOpen = !_isOpen;
        }
        
    }

    public void Activate() {
        if(!_isOpen) {
            Vector3 pos = transform.position + _dPos;
            transform.position = pos;
            _isOpen = true;
        }
    } 
    public void Deactivate() {
        if(_isOpen){
            Vector3 pos = transform.position - _dPos;
            transform.position = pos;
            _isOpen = false;
        }
    } 

    public void CheckCombo(){
        Color guessOne = _monitorOne.GetComponent<Renderer>().material.color;
        Color guessTwo = _monitorTwo.GetComponent<Renderer>().material.color;
        Color guessThree = _monitorThree.GetComponent<Renderer>().material.color;

        if(guessOne == Color.green && guessTwo == Color.red && guessThree == Color.blue){
            _isLocked = false;
            print("You Got It!");
            Activate();
        } else {
            print("Wrong Code!");
        }
    }
 }
