using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private string progressKeys;

    private string pathName = "/Saves/";
    private string saveName = "Save_";
    private string extension = ".rep";

    private void Awake()
    {
        if (!Directory.Exists(Application.persistentDataPath + pathName))
        {
            Directory.CreateDirectory(Application.persistentDataPath + pathName);
        }
    }

    public bool CheckSave(int number)
    {
        string path = Application.persistentDataPath + pathName;

        if (!Directory.Exists(path))
        {
            Debug.Log("Directory deleted in game time");
            Directory.CreateDirectory(path);
        }

        path += saveName + number + extension;

        if (File.Exists(path))
        {
            return true;
        }

        return false;
    }

    public void SaveGame(int number)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + pathName + saveName + number + extension;

        Debug.Log(path);

        FileStream stream = new FileStream(path, FileMode.Create);

        Save save = new Save(saveName + number, playerMovement.GetPosition(), player.GetItems(), progressKeys);

        formatter.Serialize(stream, save);
        stream.Close();

    }

    public Save LoadSave(int number)
    {
        string path = Application.persistentDataPath + pathName + saveName + number + extension;

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Save save = formatter.Deserialize(stream) as Save;
            stream.Close();

            save.SaveDebug();
            return save;
        }
        else
        {
            Debug.Log("NO FILE");
            return null;
        }
    }
}
