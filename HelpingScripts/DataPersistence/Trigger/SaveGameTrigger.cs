using UnityEngine;

public class SaveGameTrigger : MonoBehaviour
{
    [SerializeField] DataPersistanceManager saveScript;
    [SerializeField] float delay = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Invoke(nameof(SaveTheGame), delay);
        }
    }

    private void SaveTheGame()
    {
        saveScript.SaveGame();
    }
}
