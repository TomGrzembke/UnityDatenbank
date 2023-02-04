using UnityEngine;

/// <summary>
/// Add this component to a gameObj with a collider where the enableed should be saved. Count the collider ID up by one from the last added one and update the GameData Array for this
/// </summary>
public class ColliderSaveBehavior : MonoBehaviour, IDataPersistence
{
    #region Variables
    /// <summary>
    /// This id will be used for the saving of this obj
    /// </summary>
    [SerializeField] int colliderID;
    [SerializeField] bool disablesOnTrigger = true;
    #endregion

    #region Access
    Collider2D objCollider;
    private void Awake()
    {
        objCollider = GetComponent<Collider2D>();
    }
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        if (!disablesOnTrigger) return;

        objCollider.enabled = false;

    }
    #region Save
    /// <summary>
    /// Loads the data from the json file at the start of the game
    /// </summary>
    /// <param name="data">Data which origin is a json from the system , which gets converted by the data handler to get passed here </param>
    public void LoadData(GameData data)
    {
        objCollider.enabled = data.colliderShouldBeEnabled[colliderID];
    }

    /// <summary>
    /// Saves the wanted data when quitting the application or when the game is saved
    /// </summary>
    /// <param name="data">Data which will be converted to a json in the system by the DataHandler</param>
    public void SaveData(ref GameData data)
    {
        data.colliderShouldBeEnabled[colliderID] = objCollider.enabled;
    }
    #endregion

}

