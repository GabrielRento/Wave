using UnityEngine;
using TMPro;

public class PlayerTouchManager : MonoBehaviour
{
    private Camera mainCamera;
    public float hitZoneDistance = 1.0f; // Ajuste esse valor na Unity

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        HandleTouchInput();
    }

    void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Controlador de estados
            switch (touch.phase)
            {
                case TouchPhase.Moved:
                    //Dedo movimentando
                    CheckNoteHit(touch.position);
                    break;
                case TouchPhase.Stationary:
                    //Dedo parado
                    break;
            }
        }
    }

    void CheckNoteHit(Vector2 touchPosition)
    {
        Vector3 worldPos = mainCamera.ScreenToWorldPoint(touchPosition);

        // Faz um raycast na posição do toque
        RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);

        if (hit.collider != null)
        {
            // Verifica se acertou uma nota
            if (hit.collider.CompareTag("Note"))
            {
                Note note = hit.collider.GetComponent<Note>();

                // Só pontua se a nota estiver perto do centro
                if (note.IsInHitZone(hitZoneDistance))
                {
                    GameManager.Instance.AddScore(1);
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}