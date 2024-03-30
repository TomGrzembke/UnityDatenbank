using UnityEngine;

public class Parallax : MonoBehaviour
{
    Vector2 startpos;
    Vector2 dist;
    [SerializeField] GameObject cam;
    [SerializeField] Vector2 parallaxEffect;


    void Start()
    {
        startpos.x = transform.position.x;
        startpos.y = transform.position.y;
    }

    void FixedUpdate()
    {
        dist.x = cam.transform.position.x * parallaxEffect.x;
        dist.y = cam.transform.position.y * parallaxEffect.y;
        transform.position = new (startpos.x + dist.x, startpos.y + dist.y, transform.position.z);
    }
}
