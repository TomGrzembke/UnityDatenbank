using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// The Manager for Scene switching
/// </summary>
public class SceneLoadManager : MonoBehaviour
{
    [SerializeField] Texture2D normalCursor;
    /// <summary>
    /// Changes the scene to the mainMenuScene
    /// </summary>
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void ChangeSceneTo(int index = 1)
    {
        if(normalCursor != null)
        Cursor.SetCursor(normalCursor, new Vector2(16, 16), CursorMode.Auto);

        SceneManager.LoadScene(index);
    }
}

