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
    public int Score;

    public GameObject LosePanel;

    public Text ScoreUIText;
    public Text FinalScoreText;
    string SCORE_MESSAGE = "Saved {0} ships";

    public Text DeathsUIText;

    public OnboardingManager Onboarding;

    public GameObject ScoreSound;

    void Start()
    {
        if (Instance == null)
            Instance = this;

        Onboarding = GameObject.Find("Onboarding").GetComponent<OnboardingManager>();

        Reset();
    }

    private void Reset()
    {
        LosePanel.SetActive(false);

        _Deaths = Deaths;
        Score = 0;
        ScoreUIText.text = Score.ToString();
        DeathsUIText.text = (_Deaths).ToString();

        Onboarding.Restart();
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
        ScoreSound.SetActive(false);
        ScoreSound.SetActive(true);
        Score++;
        ScoreUIText.text = Score.ToString();
    }

    public void ReducePoint()
    {
        _Deaths--;

        DeathsUIText.text = (_Deaths).ToString();

        if (_Deaths <= 0)
            LoseGame();
    }

    public void LoseGame()
    {
        FinalScoreText.text = string.Format(SCORE_MESSAGE, Score);

        Onboarding.InterruptOnboarding();

        LosePanel.SetActive(true);
        Time.timeScale = 0;
    }
}
