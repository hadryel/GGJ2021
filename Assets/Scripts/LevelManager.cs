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
    public Text FunnyFinalMessageText;
    public Text YouLostText;
    string SCORE_MESSAGE = "Saved {0} ships";

    public Text DeathsUIText;

    public OnboardingManager Onboarding;

    public GameObject ScoreSound;

    public string[] YouLostPhrases;

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

        DeathsUIText.text = (Deaths - _Deaths).ToString();

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

    public void SetupFinalPhrase()
    {
        if (Score <= 4)
        {
            FunnyFinalMessageText.text = "Few sailors survived to tell the story";
        }
        else if (Score <= 10)
        {
            FunnyFinalMessageText.text = "This keeper was caught Between the Devil and the Deep Blue Sea";

        }
        else if (Score <= 15)
        {
            FunnyFinalMessageText.text = "These odds are not enlighting";

        }
        else if (Score <= 20)
        {
            FunnyFinalMessageText.text = "This is a Lighthome, not a Lighthouse";

        }
        else
        {
            FunnyFinalMessageText.text = "\"Damn you, keeper they said...\" No one saw you fit for the job anyway.";
        }

        YouLostText.text = YouLostPhrases[Random.Range(0, YouLostPhrases.Length)];
    }

    public void AddLife()
    {
        _Deaths++;
        DeathsUIText.text = _Deaths.ToString();
    }

    public int GetLifes()
    {
        return _Deaths;
    }
}
