using System.Collections;
using UnityEngine;

public class SpriteFlash : MonoBehaviour
{
    [Header("Flash Settings")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float flashDuration = 0.1f;
    [SerializeField] private Color flashColor = Color.red;
    private Color originalColor;
    private Coroutine flashCoroutine;

    void Awake()
    {
        originalColor = spriteRenderer.color;
    }
    public void Flash()
    {
        if(flashCoroutine != null)
        {
            StopCoroutine(flashCoroutine);
        }
        flashCoroutine = StartCoroutine(FlashCorutine());
    }
    private IEnumerator FlashCorutine()
    {
        spriteRenderer.color = flashColor;
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor;
        flashCoroutine = null;
    }
}
