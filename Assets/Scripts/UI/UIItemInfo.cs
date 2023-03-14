using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIItemInfo : MonoBehaviour
{
    [Header("Info panel")]
    [SerializeField] private GameObject InfoPanel;

    private List<InventoryItemButtons> inventoryItemButtons;

    List<string> itemNames = new List<string>();
    List<string> itemTexts = new List<string>();

    [Header("Texts panels")]
    [SerializeField] private TMPro.TextMeshProUGUI itemName;
    [SerializeField] private TMPro.TextMeshProUGUI itemText;

    private void Awake()
    {
        inventoryItemButtons = gameObject.GetComponentsInChildren<InventoryItemButtons>().ToList();
    }

    public void UpdateMassives(List<string> itemNames, List<string> itemTexts)
    {
        this.itemNames = itemNames;
        this.itemTexts = itemTexts;

        for (int i = 0; i < itemNames.Count; i++)
        {
            inventoryItemButtons[i].ActiveButton(true);
        }
        for (int i = itemNames.Count; i < inventoryItemButtons.Count; i++)
        {
            inventoryItemButtons[i].ActiveButton(false);
        }
    }

    public void SetParams(InventoryItemButtons button)
    {
        InfoPanel.SetActive(true);

        int id = button.id;
        if (id >= itemNames.Count)
        {
            itemName.text = "No item";
            itemText.text = "No text";
            return;
        }

        SetName(id);
        SetText(id);
    }

    private void SetName(int id)
    {
        itemName.text = itemNames[id];
    }

    private void SetText(int id)
    {
        itemText.text = itemTexts[id];
    }

}
