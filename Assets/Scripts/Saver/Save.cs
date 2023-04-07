using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save
{
    private string saveName;
    private (float, float) position;
    private (string, string) items;
    private string keys;

    public Save(string saveName, (float, float) position, (string, string) items, string keys)
    {
        this.saveName = saveName;
        this.position = position;
        this.items = items;
        this.keys = keys;
    }

    public void SaveDebug()
    {
        Debug.Log(saveName);
        Debug.Log(position);
        Debug.Log(items);
        Debug.Log(keys);
    }

}
