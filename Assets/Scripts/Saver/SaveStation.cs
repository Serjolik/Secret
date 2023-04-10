using UnityEngine;

public class SaveStation : TriggeredByPlayerObject
{
    [SerializeField] private UISaves uiSaves;

    private SaveSystem saveSystem;

    protected override void Awake()
    {
        base.Awake();
        saveSystem = GameObject.FindGameObjectWithTag("SaveSystem").GetComponent<SaveSystem>();

        if (uiSaves == null)
        {
            Debug.LogWarning("uiSaves is null");
        }
        if (saveSystem == null)
        {
            Debug.LogWarning("saveSystem is null");
        }
    }

    protected override void Trigger()
    {
        if (uiSaves.opened)
        {
            uiSaves.CloseWindow();
            return;
        }

        uiSaves.OpenWindow();
    }

}
