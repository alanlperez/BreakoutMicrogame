using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int lives = 3;

    [SerializeField]
    private Text livesText;
    
    int numOfBricks;

    [SerializeField]
    private Text bricksText;

    public GameObject gameOverUI;

    bool gameOver;
    void Awake()
    {
        livesText.text = "Lives: " + lives.ToString();
        numOfBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
        bricksText.text = "Bricks: " + numOfBricks.ToString();
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver && Input.anyKeyDown)
            Restart();
    }

    public void LoseLive()
    {
        lives--;
        livesText.text = "Lives: " + lives.ToString();
        if (lives <= 0)
            GameOver();
    }

    void GameOver()
    {
        gameOver = true;
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;

    }

    public void HitBrick()
    {
        numOfBricks--;
        bricksText.text = "Bricks: " + numOfBricks.ToString();
        if (numOfBricks <= 0)
            Invoke("NextLevel", 2f);
    }

    void NextLevel()
    {
        SceneManager.LoadScene("level02");
    }

    void Restart()
    {
        SceneManager.LoadScene("level01");
        Time.timeScale = 1f;
    }
}
