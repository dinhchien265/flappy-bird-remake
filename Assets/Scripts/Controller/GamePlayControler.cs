using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayControler instance;
    [SerializeField]
    private Button intructionButton;
    [SerializeField]
    private Text endScoreText, bestScoreText,scoreText;
    [SerializeField]
    private GameObject GameOverPanel;
    private void Awake()
    {
        Time.timeScale = 0;
        MakeInstance();
    }
    public void IntructionButton()
    {
        Time.timeScale = 1;
        intructionButton.gameObject.SetActive(false);
    }
    public void SetScore(int score)
    {
        scoreText.text = "" + score;
    }
    private void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void BirdDieShowPanel(int score)
    {
        endScoreText.text = "End Score : " + score;
        if (score > GameManager.instance.GetHighScore())
        {
            bestScoreText.text ="Best Score : "+ score;
            GameManager.instance.SetHighScore(score);
        }
        else
        {
            bestScoreText.text = "Best Score : " + GameManager.instance.GetHighScore();
        }
        GameOverPanel.gameObject.SetActive(true);
    }
    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(Application.loadedLevel);
    }
}
