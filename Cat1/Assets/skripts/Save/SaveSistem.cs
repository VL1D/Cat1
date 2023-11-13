using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSistem 
{
  
    public static void SavePlayer(PlayerController player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        DataPlayer data = new DataPlayer(player);

        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log("Гра збережена");
    }

    public static  DataPlayer LoadPlayer() 
    {
        string path = Application.persistentDataPath + "/player.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path,FileMode.Open);

            DataPlayer data = formatter.Deserialize(stream) as DataPlayer;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Файл збереження не знайден" + path);
            return null;
        }
    }
    
}
