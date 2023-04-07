using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private string progressKeys;

    private string pathName = "/Saves/";
    private string extension = ".rep";

    private void Awake()
    {
        if (!Directory.Exists(Application.persistentDataPath + pathName))
        {
            Directory.CreateDirectory(Application.persistentDataPath + pathName);
        }
    }

    public void SaveGame(string saveName)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + pathName + saveName + extension;

        Debug.Log(path);

        FileStream stream = new FileStream(path, FileMode.Create);

        Save save = new Save(saveName, playerMovement.GetPosition(), player.GetItems(), progressKeys);

        formatter.Serialize(stream, save);
        stream.Close();

    }

    public Save LoadSave(string saveName)
    {
        string path = Application.persistentDataPath + pathName + saveName + extension;

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
