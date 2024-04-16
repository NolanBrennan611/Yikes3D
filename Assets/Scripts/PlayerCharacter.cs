using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerCharacter : Character
{
    [SerializeField] private HealthBar _healthBarPrefab;
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private GameObject _knifePrefab;
    private HealthBar _healthBar;
    private Vector3 _originalPosition;
    [SerializeField] Inventory _inventoryPrefab;
    private Inventory _inventory;
    
    // Start is called before the first frame update
    void Start()
    {
        _hitPoints.Value = _startingHitPoints;
        _healthBar = Instantiate(_healthBarPrefab);
        _healthBar.Character = this;
        _originalPosition = transform.position;
        _inventory = Instantiate(_inventoryPrefab);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.H)){
            _inventory.SendMessage("Consume");
        }

    }

    public bool AdjustHitPoints(int amount) {
        if (_hitPoints.Value < _maxHitPoints) {
            _hitPoints.Value = _hitPoints.Value + amount;
            if(_hitPoints.Value <= 0){     
                Death();
            } else if(_hitPoints.Value > 10){
                _hitPoints.Value = 10;
            }
            print("Adjusted HP by: " + amount + ". New value: " + _hitPoints.Value);
            return true;
        }
        return false;
    }
    
    private void Death(){
        print("died");
        bool canFire = GameObject.FindWithTag("MainCamera").GetComponent<RayShooter>().WeaponInstance();
        Destroy(gameObject);
        if(canFire){
            Instantiate(_knifePrefab, _originalPosition, Quaternion.identity);
        }
        Instantiate(_playerPrefab, _originalPosition, Quaternion.identity);
    }
    void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("PickUp")) {
            print("HIT");
            ItemData hitObject = collision.gameObject.GetComponent<Consumable>().Item;
            if (hitObject != null) {
                print("Hit: " + hitObject.ObjectName);
                bool shouldDisappear = false;
                switch (hitObject.Type) {
                    case ItemData.ItemType.Score:
                        shouldDisappear = _inventory.AddItem(hitObject);
                    break;
                    case ItemData.ItemType.Health:
                        shouldDisappear = _inventory.AddItem(hitObject);
                    break;
                    case ItemData.ItemType.Weapon:
                        GameObject.FindWithTag("MainCamera").GetComponent<RayShooter>().EnableWeapon();
                    break;
                }
                collision.gameObject.SetActive(false);
            }
        }
    }


}
