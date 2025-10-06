using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public GameObject notePrefab;
    public Transform topSpawn;
    public Transform leftSpawn;
    public Transform rightSpawn;
    public Transform bottomSpawn;

    private float songTime;
    private int nextNoteIndex = 0;

    void Update()
    {
        songTime += Time.deltaTime;

        if (nextNoteIndex < OdeToJoyMap.notes.Length)
        {
            NoteData currentNote = OdeToJoyMap.notes[nextNoteIndex];

            if (songTime >= currentNote.spawnTime)
            {
                SpawnNote(currentNote.direction);
                nextNoteIndex++;
            }
        }
    }

    void SpawnNote(int direction)
    {
        Transform spawnPoint = topSpawn;
        Quaternion rotation = Quaternion.identity;

        switch (direction)
        {
            case 0:
                spawnPoint = topSpawn;
                rotation = Quaternion.Euler(0, 0, -90f);
                break;
            case 1:
                spawnPoint = leftSpawn;
                rotation = Quaternion.Euler(0, 0, 0f);
                break;
            case 2:
                spawnPoint = rightSpawn;
                rotation = Quaternion.Euler(0, 0, 180f);
                break;
            case 3:
                spawnPoint = bottomSpawn;
                rotation = Quaternion.Euler(0, 0, 90f);
                break;
        }

        GameObject note = Instantiate(notePrefab, spawnPoint.position, rotation);
        note.GetComponent<Note>().SetDirection(direction);
    }
}