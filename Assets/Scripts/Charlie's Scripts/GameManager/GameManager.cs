using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region GAMEMANAGER
    public static GameManager _GAME_MANAGER;
    #endregion

    #region Spawner
    public GameObject ball;
    public int num= 0;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    float x;
    float y;
    Vector2 randomPos;
    #endregion

    #region Score&HighScore
    public Text scoreText;
    public Text highscoreText;

    int score = 0;
    int highscore = 0;
    #endregion

    #region PowerUps
    public bool isGodModeActive;
    public bool isSmallArenaActive;
    public float godModeTime;
    public float smallArenaTime;
    public Transform Walls;
    #endregion

    private void Awake()
    {
        if (_GAME_MANAGER != null && _GAME_MANAGER != this)
        {
            Destroy(_GAME_MANAGER);

        }
        else
        {
            _GAME_MANAGER = this;
            DontDestroyOnLoad(this);
        }
    }

    private void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = score.ToString();
        highscoreText.text = highscore.ToString();
    }

    void Update()
    {
        x = Random.Range(minX, maxX);
        y = Random.Range(minY, maxY);
        randomPos = new Vector2(x, y);
        scoreText.text = score.ToString();
        if (num == 5)
        {
            SpawnBall();
        }
        if (isGodModeActive)
        {
            godModeTime -= Time.deltaTime;
            if (godModeTime <= 0f)
            {
                isGodModeActive = false;
                godModeTime = 1f;
            }
        }
        if (isSmallArenaActive)
        {
            
            smallArenaTime -= Time.deltaTime;
            if (smallArenaTime <= 0f)
            {
                isSmallArenaActive = false;
                smallArenaTime = 1f;
            }
        }
    }

    public void SpawnBall()
    {
        Instantiate(ball, randomPos, Quaternion.identity);
        num = 0;
    }

    public void AddPoint()
    {
        score++;
        
        if (highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }

    public void ExtraPoints()
    {
        score += 100;
    }
    public void GodMode()
    {
        isGodModeActive = true;
        
    }
    public void SmallArena()
    {
        isSmallArenaActive = true;
       
    }
}
