
using UnityEngine;

/// <summary>
/// The behavior of each enemy bullet shot
/// </summary>
public class BulletBehavior : MonoBehaviour
{

    #region stats
    /// <summary>
    /// The speed which the bullet will use to calculate
    /// </summary>
    public float speed;
    /// <summary>
    /// The GameObject which collided with the bullet
    /// </summary>
    GameObject target;

    [SerializeField] int damage = -1;
    #endregion

    #region Start
    /// <summary>
    /// Invokes the destroyItself function
    /// </summary>
    private void Start()
    {
        Invoke(nameof(DestroyItself), 5f);
    }

    /// <summary>
    /// Transforms the position of the bullet in the given direction
    /// </summary>
    void FixedUpdate()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.left);
    }
    #endregion

    #region Destroy
    /// <summary>
    /// Destroys the GameObject
    /// </summary>
    void DestroyItself() //Destroys the gameObject
    {
        Destroy(gameObject);
    }
    #endregion

    /// <summary>
    /// Is used for the trigger component on the bullet
    /// </summary>
    /// <param name="collision">Collision is the GameObject which triggered the bullet</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Props"))
        {
            DestroyItself();
        }
        else if (collision.CompareTag("Player"))
        {
            target = collision.gameObject;
            target.GetComponent<PlayerBattle>().ApplyDamage(damage);
        }

    }
}
