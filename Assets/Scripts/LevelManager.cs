using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public int Deaths = 3;
    public int Score = 0;

    int _Deaths;
    int _Score;

    public GameObject LosePanel;

    public Text ScoreText;
    string SCORE_MESSAGE = "Saved {0} ships";

    void Start()
    {
        if (Instance == null)
            Instance = this;

        Reset();
    }

    private void Reset()
    {
        LosePanel.SetActive(false);

        _Deaths = Deaths;
        _Score = 0;
    }
    void Update()
    {
        
    }

    public void PlayAgain()
    {
        Reset();
        SceneManager.LoadScene("LevelScene");
        Time.timeScale = 1;
    }

    public void ScorePoint()
    {
        Score++;
    }

    public void ReducePoint()
    {
        _Deaths--;

        if (_Deaths <= 0)
            LoseGame();
    }

    public void LoseGame()
    {
        ScoreText.text = string.Format(SCORE_MESSAGE, _Score);

        LosePanel.SetActive(true);
        Time.timeScale = 0;
    }
}
