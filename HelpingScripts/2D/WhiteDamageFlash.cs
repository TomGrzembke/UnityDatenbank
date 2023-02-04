using System.Collections;
using UnityEngine;

public class WhiteDamageFlash : MonoBehaviour
{
    #region Variables
    [SerializeField] float flashDuration;
    #endregion

    #region Access
    [SerializeField] Material flashMaterial;
    Material originalMaterial;
    Coroutine flashCoroutine;
    SpriteRenderer sr;
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        originalMaterial = sr.material;
    }
    #endregion

    public void Flash()
    {
        if (flashCoroutine != null)
        {
            StopCoroutine(flashCoroutine);
        }

        flashCoroutine = StartCoroutine(FlashRoutine());
    }
    IEnumerator FlashRoutine()
    {
        sr.material = flashMaterial;
        yield return new WaitForSeconds(flashDuration);
        sr.material = originalMaterial;
        flashCoroutine = null;
    }
}

