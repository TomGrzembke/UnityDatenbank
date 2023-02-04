using UnityEngine;

public class Parallex : MonoBehaviour
{
    private float startposX;
    private float startposY;
    public GameObject cam;
    public float parallaxEffectX;
    public float parallaxEffectY;

    void Start()
    {
        startposX = transform.position.x;
        startposY = transform.position.y;
    }

    void FixedUpdate()
    {
        float distX = (cam.transform.position.x * parallaxEffectX);
        float distY = (cam.transform.position.y * parallaxEffectY);
        transform.position = new Vector3(startposX + distX, startposY + distY, transform.position.z);
    }
}
