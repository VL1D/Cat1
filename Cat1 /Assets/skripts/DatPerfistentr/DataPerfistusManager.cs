using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class DataPerfistusManager : MonoBehaviour
{
    [Header("Debugging")]

    [SerializeField]private bool intializeDataIfNull = false;

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
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);

        this.dataHandler = new FileDataHandier(Application.persistentDataPath, fileName, useEncryption);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }
    public void OnSceneLoaded(Scene scene,LoadSceneMode mode)
    {
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void OnSceneUnloaded(Scene scene)
    {
        SaveGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        this.gameData = dataHandler.Load();
        if(this.gameData == null && intializeDataIfNull)
        {
            NewGame();
        }
        if(this.gameData == null)
        {
            Debug.Log("Даних не знайдено. Перед завантаженням даних потрібно запустити нову гру.");
            return;
        }

        foreach(IDatPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }

    }

    public void SaveGame()
    {
        if(this.gameData == null)
        {
            Debug.LogWarning("Дані не знайдено. Перш ніж зберегти дані, потрібно запустити нову гру.");
            return;
        }
        foreach (IDatPersistence dataPesistenceObj in dataPersistenceObjects)
        {
            dataPesistenceObj.SaveData( gameData); 
        }

        dataHandler.Save(gameData );
    }

    private List<IDatPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDatPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDatPersistence>();
        return new List<IDatPersistence>(dataPersistenceObjects);
    }

    public bool HasGameData() 
    {
        return gameData != null;
    }
}
