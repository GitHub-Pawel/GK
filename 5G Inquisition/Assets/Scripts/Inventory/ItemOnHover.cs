using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemOnHover : MonoBehaviour
{
    public string myText;
    private GameObject textDisplay;
    private Text textField;
    private InventorySlot thisSlot;
    // Start is called before the first frame update
    void Start()
    {
        textDisplay = GameObject.Find("InventoryText");
        thisSlot = GetComponentInParent<InventorySlot>();
        textField = textDisplay.GetComponent<Text>();
    }

   

    public void OnMouseHoverOverButton()
    {
        Debug.Log("ON "+thisSlot.GetItemName());
        textField.text = thisSlot.GetItemName();
    }
}
