using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {


    public static ScoreManager instance;
    public int score;
    public GameObject gameOverPanel;
    public Text scoreText;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Use this for initialization
    void Start () {
        score = 0;
        //PlayerPrefs.SetInt("Score", 0);
    }
	
	// Update is called once per frame
	void Update () {
        scoreText.text = score.ToString();
	}

    public void IncrementScore()
    {
        score++;
    }

    /*
    public void StopScore()
    {
        PlayerPrefs.SetInt("Score", score);
        if (PlayerPrefs.HasKey("HighScore"))
        {
            if (score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
    */

    public void Replay()
    {
        SceneManager.LoadScene("level1");
        
    }

    public void gameOver() {
        gameOverPanel.SetActive(true);
        gameOverPanel.GetComponent<Animator>().Play("panelUp");
    }
}
