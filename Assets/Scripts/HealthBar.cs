using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private HitPoints _hitPoints;
    [SerializeField] private Image _meterImage;
    private PlayerCharacter _character;

    public PlayerCharacter Character {
        get { return _character; }
        set { _character = value; }
    }

    void Update(){
        if (_character != null) {
            _meterImage.fillAmount = _hitPoints.Value / _character.MaxHitPoints;
        }
    }
}
