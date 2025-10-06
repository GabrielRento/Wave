using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public AudioSource music;
    public TMP_Text scoreText;
    public float musicStartDelay = 0f;
    public GameObject gameOverImage;
    public GameObject victoryImage;

    private int score;
    private int missCount = 0;
    private bool gameEnded = false;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Invoke("PlayMusic", musicStartDelay);
        gameOverImage.SetActive(false);
        victoryImage.SetActive(false);
        UpdateScoreUI();
    }

    void Update()
    {
        if (!gameEnded && !music.isPlaying && Time.timeSinceLevelLoad > musicStartDelay + 1f)
        {
            Victory();
        }
    }

    void PlayMusic()
    {
        music.Play();
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScoreUI();
        HitZoneFeedback.Instance.ShowHit(); // Feedback de acerto
    }

    public void AddMiss()
    {
        missCount++;
        if (missCount >= 3 && !gameEnded)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameEnded = true;
        Time.timeScale = 0f;
        music.Stop();
        gameOverImage.SetActive(true);
        StartCoroutine(ReloadSceneAfterDelay());
    }

    void Victory()
    {
        gameEnded = true;
        Time.timeScale = 0f;
        victoryImage.SetActive(true);
        StartCoroutine(ReloadSceneAfterDelay());
    }

    IEnumerator ReloadSceneAfterDelay()
    {
        yield return new WaitForSecondsRealtime(5f);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }

    public int GetScore()
    {
        return score;
    }
}