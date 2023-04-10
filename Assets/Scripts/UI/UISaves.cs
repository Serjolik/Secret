using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISaves : MonoBehaviour
{
    [SerializeField] private List<GameObject> saveObject;
    [Space]
    [Header("Events")]
    [SerializeField] private GameEvent pauseEvent;
    [SerializeField] private GameEvent resumeEvent;
    private SaveSystem saveSystem;

    public bool opened { get; private set; }

    private void Awake()
    {
        saveSystem = GameObject.FindGameObjectWithTag("SaveSystem").GetComponent<SaveSystem>();
    }

    private void Start()
    {
        foreach (GameObject obj in saveObject)
        {
            obj.SetActive(false);
        }
    }

    public void OpenWindow()
    {
        gameObject.GetComponent<Image>().enabled = true;

        int index = 0;
        foreach (GameObject obj in saveObject)
        {
            obj.SetActive(true);
            UpdatePanel(index);

            index++;
        }

        pauseEvent.TriggerEvent();
        opened = true;
    }

    public void CloseWindow()
    {
        gameObject.GetComponent<Image>().enabled = false;
        foreach (GameObject obj in saveObject)
        {
            obj.SetActive(false);
        }

        resumeEvent.TriggerEvent();
        opened = false;
    }

    private void Update()
    {
        if (!opened)
            return;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseWindow();
        }
    }

    public void UpdatePanel(int panelIndex)
    {
        if (!saveSystem.CheckSave(panelIndex))
        {
            StandartPanelLoad(panelIndex);
            return;
        }

        Save save = saveSystem.LoadSave(panelIndex);

        var texts = saveObject[panelIndex].GetComponentsInChildren<TMPro.TextMeshProUGUI>();
        texts[0].text = save.getName();


    }

    private void StandartPanelLoad(int panelIndex)
    {
        var texts = saveObject[panelIndex].GetComponentsInChildren<TMPro.TextMeshProUGUI>();
        texts[0].text = "Empty slot";
    }

    public void WriteSave(int buttonId)
    {
        saveSystem.SaveGame(buttonId);
    }
}
