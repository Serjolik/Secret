using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIListPanel : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private GameObject ObjectivesPanel;
    [SerializeField] private GameObject SettingsPanel;

    private bool inOtherMenu = false;

    public void InventoryPressed()
    {
        inventoryPanel.SetActive(true);
        inOtherMenu = true;
    }

    public void ObjectivesPressed()
    {
        ObjectivesPanel.SetActive(true);
        inOtherMenu = true;
    }

    public void SettingsPressed()
    {
        SettingsPanel.SetActive(true);
        inOtherMenu = true;
    }

    public void MainMenuPressed()
    {
        return;
    }

    public void ExitPressed()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (inOtherMenu)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                inOtherMenu = false;
                AllPanelsState(false);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Close();
            }
        }
    }

    private void Close()
    {
        this.gameObject.SetActive(false);
    }

    private void AllPanelsState(bool state)
    {
        if (state == false)
        {
            inventoryPanel.SetActive(false);
            infoPanel.SetActive(false);
            ObjectivesPanel.SetActive(false);
            SettingsPanel.SetActive(false);
        }

    }

}
