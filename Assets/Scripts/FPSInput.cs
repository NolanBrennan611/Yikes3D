using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class FPSInput : MonoBehaviour {
    [SerializeField] private float _speed = 6.0f;
    [SerializeField] private float _gravity = -9.8f;
    private CharacterController _charController;
    [SerializeField] private float _jumpSpeed = 15.0f;
    [SerializeField] private float _terminalVelocity = -10.0f;
    [SerializeField] private float _minimumFall = -1.5f;
    private float _verticalSpeed;
    void Start() {
        _charController = GetComponent<CharacterController>();
        _verticalSpeed = _minimumFall;
    }
    void Update() {
        if (_charController.isGrounded){
            if (Input.GetKeyDown(KeyCode.Space)) {
                _verticalSpeed = _jumpSpeed;
            } else {
                _verticalSpeed = _minimumFall;
            }
        } else {
            _verticalSpeed += _gravity * Time.deltaTime;
            if (_verticalSpeed < _terminalVelocity) {
                _verticalSpeed = _terminalVelocity;
            }
        }

        float deltaX = Input.GetAxis("Horizontal") * _speed;
        float deltaZ = Input.GetAxis("Vertical") * _speed;
        Vector3 movement = new Vector3(deltaX, _verticalSpeed, deltaZ); 
        movement = Vector3.ClampMagnitude(movement, _speed) * Time.deltaTime; 
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);
    }

}
