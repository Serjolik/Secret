using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemButtons : MonoBehaviour
{
    public int id { get; private set; }
    private Button button;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.interactable = false;
        button.targetGraphic = gameObject.GetComponent<Image>();

        id = gameObject.name[gameObject.name.Length - 2] - '0';
    }

    public void ActiveButton(bool state)
    {
        button.interactable = state;
    }

}
