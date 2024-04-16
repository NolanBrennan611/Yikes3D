using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _qtyText;
    public TextMeshProUGUI QtyText{
        get {
            return _qtyText;
        }
    }
}
