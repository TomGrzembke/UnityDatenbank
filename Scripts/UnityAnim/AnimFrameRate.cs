using UnityEngine;

public class AnimFrameRate : MonoBehaviour
{
    Animator anim;
    [SerializeField] int frameRate = 12;
    float lastRenderTime = 0;
    float savedAnimSpeed;
    string clipName;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        savedAnimSpeed = anim.speed;
        clipName = anim.GetCurrentAnimatorClipInfo(0)[0].clip.name;
    }

    void Update()
    {
        if (Time.time - lastRenderTime > 1f / frameRate)
        {
            float clipLength = anim.GetCurrentAnimatorClipInfo(0)[0].clip.length;
            float clipProgressionAlpha = anim.GetCurrentAnimatorStateInfo(0).normalizedTime;

            lastRenderTime = Time.time;
            anim.Play(clipName, 0, clipProgressionAlpha + 1f / frameRate / clipLength * savedAnimSpeed);
            anim.speed = 0;
        }
    }
}