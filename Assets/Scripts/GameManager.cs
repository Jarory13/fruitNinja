using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public bool gameOver;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Use this for initialization
    void Start () {
        gameOver = true;
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    public void GameStart() {
        if (!gameOver)
        {
            GameObject.Find("FruitSpawner").GetComponent<FruitSpawner>().InvokeFruit();
            ScoreManager.instance.gameOverPanel.SetActive(false);
        }
    }

    public void GameOver()
    {
        GameObject.Find("FruitSpawner").GetComponent<FruitSpawner>().StopSpawning();
    }
}
