using UnityEngine;

public class Note : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 target = Vector3.zero;
    private int direction;

    public void SetDirection(int direction)
    {
        this.direction = direction;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            HitZoneFeedback.Instance.ShowMiss();
            GameManager.Instance.AddMiss();
            Destroy(gameObject);
        }
    }

    public bool IsInHitZone(float maxDistance = 1.0f)
    {
        return Vector3.Distance(transform.position, target) <= maxDistance;
    }
}