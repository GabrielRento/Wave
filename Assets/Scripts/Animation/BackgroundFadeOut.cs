using UnityEngine;

public class BackgroundFadeOut : MonoBehaviour
{
    [SerializeField] private Color startColor = Color.blue;
    [SerializeField] private Color endColor = Color.black;
    [SerializeField] private float fadeDuration = 1f;

    private Camera cam;
    private float timer;

    void Start()
    {
        cam = GetComponent<Camera>();
        cam.backgroundColor = startColor;
    }

    void Update()
    {
        if (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            cam.backgroundColor = Color.Lerp(startColor, endColor, timer / fadeDuration);
        }
    }
}
