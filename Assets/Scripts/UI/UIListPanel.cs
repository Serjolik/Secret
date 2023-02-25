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

    private PlayerMovement playerMovement;

    private bool inMenu = false;
    private bool inOtherPanel = false;

    private void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

        MenuClose();
        AllPanelsState(false);
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
        playerMovement.CanMove = false;
        ListPanel.SetActive(true);
        inMenu = true;
    }

    private void MenuClose()
    {
        playerMovement.CanMove = true;
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
