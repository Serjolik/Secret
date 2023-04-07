using UnityEngine;

public class SaveStation : TriggeredByPlayerObject
{
    private SaveSystem saveSystem;

    protected override void Awake()
    {
        base.Awake();
        saveSystem = GameObject.FindGameObjectWithTag("SaveSystem").GetComponent<SaveSystem>();
    }

    protected override void Trigger()
    {
        saveSystem.SaveGame("Test");
        saveSystem.LoadSave("Test");
    }

}
