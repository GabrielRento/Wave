using UnityEngine;
using System.Collections;

public class HitZoneFeedback : MonoBehaviour
{
    public static HitZoneFeedback Instance;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private Vector3 originalScale;

    void Awake()
    {
        Instance = this;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        originalScale = transform.localScale;
    }

    public void ShowMiss()
    {
        spriteRenderer.color = Color.red;
        Invoke("ResetColor", 0.3f);
    }

    public void ShowHit()
    {
        StartCoroutine(HitAnimation());
    }

    IEnumerator HitAnimation()
    {
        float duration = 0.2f;
        float elapsed = 0f;
        float scaleMultiplier = 1.25f;

        while (elapsed < duration)
        {
            elapsed += Time.unscaledDeltaTime;
            float t = elapsed / duration;
            float scale = Mathf.Lerp(scaleMultiplier, 1f, t);
            transform.localScale = originalScale * scale;
            yield return null;
        }

        transform.localScale = originalScale;
    }

    void ResetColor()
    {
        spriteRenderer.color = originalColor;
    }
}