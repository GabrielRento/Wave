// essa classe define a estrutura da nota.

using UnityEngine;

[System.Serializable]
public class NoteData
{
    public float spawnTime; // tempo em segundos para da spawn na nota
    public int direction; // 0 = cima, 1 = esquerda,  2 = direita, 3 = baixo
}
