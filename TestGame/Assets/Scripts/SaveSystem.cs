using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem : MonoBehaviour
{
    public static void SaveGame(GameManager gameManager)
    {
        BinaryFormatter bf = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save.dat";
        FileStream fs = new FileStream(path, FileMode.Create);

        GameData data = new GameData(gameManager);
        bf.Serialize(fs, data);
        fs.Close();
    }

    public static GameData LoadGame()
    {
        string path = Application.persistentDataPath + "/save.dat";
        if(File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open);

            GameData data = bf.Deserialize(fs) as GameData;
            fs.Close();
            return data;
        } else
        {
            return null;
        }
    }
}
