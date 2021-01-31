using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public int Deaths = 3;

    int _Deaths;
    int _Score;

    public GameObject LosePanel;

    public Text ScoreUIText;
    public Text FinalScoreText;
    string SCORE_MESSAGE = "Saved {0} ships";

    public Text DeathsUIText;

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
        ScoreUIText.text = _Score.ToString();
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
        _Score++;
        ScoreUIText.text = _Score.ToString();
    }

    public void ReducePoint()
    {
        _Deaths--;

        DeathsUIText.text = (Deaths - _Deaths).ToString();

        if (_Deaths <= 0)
            LoseGame();
    }

    public void LoseGame()
    {
        FinalScoreText.text = string.Format(SCORE_MESSAGE, _Score);

        LosePanel.SetActive(true);
        Time.timeScale = 0;
    }
}
