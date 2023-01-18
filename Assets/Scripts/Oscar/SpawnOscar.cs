using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnOscar : MonoBehaviour
{
    //Spawner
    public GameObject Circle;
    private int num= 0;

    public float x;
    public float y;
    Vector2 randomPos;

    //Highscore
    public Text scoreText;
    public Text highscoreText;

    int score = 0;
    int highscore = 0;

    private void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = score.ToString();
        highscoreText.text = highscore.ToString();
    }

    void Update()
    {
        x = Random.Range(-10, 10);
        y = Random.Range(-5, 5);
        randomPos = new Vector2(x, y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
           num++;

           //Highscore
           AddPoint();
        }

        if (num == 5)
        {
            Instantiate(Circle, randomPos, Quaternion.identity);
            num = 0;
        }
    }

    public void AddPoint()
    {
        score++;
        scoreText.text = score.ToString();
        if (highscore < score) {
            PlayerPrefs.SetInt("highscore", score);
        }
    }
}
