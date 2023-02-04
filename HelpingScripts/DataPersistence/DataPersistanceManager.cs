using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.IO;


public class DataPersistanceManager : MonoBehaviour
{
    [Header("FileStorage Config")]
    [SerializeField] string fileName;
    [SerializeField] bool saveGameWhenQuitting = true;
    [SerializeField] Animator saveAnim;
    string dataDirPath = "";
    string dataFileName = "";

    /// <summary>
    /// A storage for the gameData that will be saved 
    /// </summary>
    GameData gameData;

    List<IDataPersistence> dataPersistenceObjects;
    /// <summary>
    /// This will be used for handling the data and converting the json to usable data
    /// </summary>
    FileDataHandler dataHandler;

    /// <summary>
    /// Modifies this class
    /// </summary>
    public static DataPersistanceManager instance { get; private set; }

    /// <summary>
    /// Throws an error if there are to instances of this class. This class is a singleton and itll create problems if it exists twice
    /// </summary>
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Theres more than one Data Persistance manager in the scene");
        }
        instance = this;
    }

    /// <summary>
    /// Loads the gamé and seeks a save filelocation for future saving
    /// </summary>
    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        SaveFileAccess(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();

        LoadGame();
    }

    /// <summary>
    /// Makes sure that GameData != null
    /// </summary>
    public void NewGame()
    {
        this.gameData = new GameData();
    }

    /// <summary>
    /// Loads any saved data with the data handler and passes those to the dataPersistenceObj. Creates a new file if there isnt one yet
    /// </summary>
    public void LoadGame()
    {
        // Load any saved data from a file using the data handler
        this.gameData = dataHandler.Load();

        //if no data can be loaded, initialize to a new game
        if (this.gameData == null)
        {
            Debug.Log("No data was found. Will use default data");
            NewGame();
        }

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }

    }

    /// <summary>
    /// Gets all scripts that use the IDataPersistence interface and saves the game data in the data handler
    /// </summary>
    public void SaveGame()
    {
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }

        dataHandler.Save(gameData);

        if (saveAnim == null) return;
        saveAnim.SetTrigger("isSaving");
    }

    /// <summary>
    /// Calls the Save Game method when to application gets quitted
    /// </summary>
    private void OnApplicationQuit()
    {
        if (saveGameWhenQuitting)
        {
            SaveGame();
        }
    }

    /// <summary>
    /// Returns a list of the objects that use the IDataPersistence interface 
    /// </summary>
    /// <returns>a list of the objects that use the IDataPersistence interface </returns>
    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistences = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
        return new List<IDataPersistence>(dataPersistences);
    }
    public void ResetGame()
    {
        string fullpath = Path.Combine(dataDirPath, dataFileName);
        File.Delete(fullpath);
    }
    public void SaveFileAccess(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }
}
