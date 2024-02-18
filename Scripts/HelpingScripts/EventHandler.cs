
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This script should be attached to an animated Object to utilize the Unity Events through this or used as a trigger
/// </summary>
public class EventHandler : MonoBehaviour
{
    /// <summary>
    /// The Event function that will be called
    /// </summary>
    [SerializeField] bool onTriggerEvent;
    [SerializeField] bool onTriggerExitEvent;
    [SerializeField] bool passToPlayerController;
    [SerializeField] string tagToCompare = "Player";
    [SerializeField] UnityEvent onEvent;
    PlayerController playerController;

    /// <summary>
    /// This can be called from animation events or from other scripts
    /// </summary>
    public void OnEvent()
    {
        onEvent.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (onTriggerExitEvent) return;
        if (!collision.CompareTag(tagToCompare)) return;
        if (onTriggerEvent)
        {
            onEvent.Invoke();
        }
        else if (passToPlayerController)
        {
            try
            {
                playerController = collision.gameObject.GetComponent<PlayerController>();
                playerController.SetCurrentEventhandler(this);

            }
            catch { }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag(tagToCompare)) return;
        try
        {
            playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.SetCurrentEventhandler(null);
        }
        catch { }

        if (!onTriggerExitEvent) return;
        onEvent.Invoke();
    }

}

