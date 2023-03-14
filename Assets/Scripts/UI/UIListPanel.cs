using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIListPanel : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject ListPanel;
    [SerializeField] private GameObject InventoryPanel;
    [SerializeField] private GameObject InfoPanel;
    [SerializeField] private GameObject ObjectivesPanel;
    [SerializeField] private GameObject SettingsPanel;

    private bool inMenu = false;
    private bool inOtherPanel = false;

    [Header("Events")]
    public GameEvent PauseEvent;
    public GameEvent PlayEvent;

    private void Start()
    {
        PanelsStartLoad();
    }

    public void InventoryPressed()
    {
        AllPanelsState(false);
        InventoryPanel.SetActive(true);
        inOtherPanel = true;
    }

    public void ObjectivesPressed()
    {
        AllPanelsState(false);
        ObjectivesPanel.SetActive(true);
        inOtherPanel = true;
    }

    public void SettingsPressed()
    {
        AllPanelsState(false);
        SettingsPanel.SetActive(true);
        inOtherPanel = true;
    }

    public void MainMenuPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitPressed()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (!Input.anyKeyDown)
        {
            return;
        }

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
        else if (Input.GetKeyDown(KeyCode.I))
        {
            InventoryOpen();
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            ObjectivesOpen();
        }
        
    }

    private void MenuOpen()
    {

        PauseEvent.TriggerEvent();
        ListPanel.SetActive(true);
        inMenu = true;
    }

    private void MenuClose()
    {
        PlayEvent.TriggerEvent();
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
        else
        {
            InventoryPanel.SetActive(true);
            InfoPanel.SetActive(true);
            ObjectivesPanel.SetActive(true);
            SettingsPanel.SetActive(true);
        }

    }

    private void InventoryOpen()
    {
        if (!inMenu)
            MenuOpen();
        InventoryPressed();
    }

    private void ObjectivesOpen()
    {
        if (!inMenu)
            MenuOpen();
        ObjectivesPressed();
    }

    private void PanelsStartLoad()
    {
        MenuOpen();
        AllPanelsState(true);
        AllPanelsState(false);
        MenuClose();
    }

}
