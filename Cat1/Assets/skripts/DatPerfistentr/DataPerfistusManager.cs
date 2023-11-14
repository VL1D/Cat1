using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPerfistusManager : MonoBehaviour
{
    [Header("File Storage Config")]

    [SerializeField] private string fileName;

    [SerializeField] private bool useEncryption;
    private GameData gameData;

    private List<IDatPersistence> dataPersistenceObjects;

    private FileDataHandier dataHandler;
   public static DataPerfistusManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Щось пішло не так!");
        }
        instance = this;
    }

    private void Start()
    {
        this.dataHandler = new FileDataHandier(Application.persistentDataPath, fileName, useEncryption);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }
    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        this.gameData = dataHandler.Load();
        if(this.gameData == null)
        {
            Debug.Log("Даних не знайдено. Ініціалізація даних за замовчуванням.");
            NewGame();
        }

        foreach(IDatPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }

    }

    public void SaveGame()
    {
        foreach (IDatPersistence dataPesistenceObj in dataPersistenceObjects)
        {
            dataPesistenceObj.SaveData( ref gameData); 
        }

        dataHandler.Save(gameData );
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDatPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDatPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDatPersistence>();
        return new List<IDatPersistence>(dataPersistenceObjects);
    }
}
