using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIListPanel : MonoBehaviour
{
    [SerializeField] private GameObject ListPanel;
    [SerializeField] private GameObject InventoryPanel;
    [SerializeField] private GameObject InfoPanel;
    [SerializeField] private GameObject ObjectivesPanel;
    [SerializeField] private GameObject SettingsPanel;

    private bool inMenu = false;
    private bool inOtherPanel = false;

    public void InventoryPressed()
    {
        InventoryPanel.SetActive(true);
        inOtherPanel = true;
    }

    public void ObjectivesPressed()
    {
        ObjectivesPanel.SetActive(true);
        inOtherPanel = true;
    }

    public void SettingsPressed()
    {
        SettingsPanel.SetActive(true);
        inOtherPanel = true;
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!inMenu)
            {
                MenuOpen();
                return;
            }

            if (!inOtherPanel)
            {
                MenuClose();
            }

            else
            {
                inOtherPanel = false;
                AllPanelsState(false);
            }
        }
    }

    private void MenuOpen()
    {
        Time.timeScale = 0f; // temporally

        ListPanel.SetActive(true);
        inMenu = true;
    }

    private void MenuClose()
    {
        Time.timeScale = 1.0f; // temporally

        ListPanel.SetActive(false);
        inMenu = false;
    }

    private void AllPanelsState(bool state)
    {
        if (state == false)
        {
            InventoryPanel.SetActive(false);
            InfoPanel.SetActive(false);
            ObjectivesPanel.SetActive(false);
            SettingsPanel.SetActive(false);
        }

    }

}
