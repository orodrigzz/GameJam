using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    #region BallParameters
    Vector2 direction;
    public float startSpeed;
    private Rigidbody2D rb;
    private float currentRadiants;
    #endregion

    #region SoftIA
    public bool isAwake;
    public Transform player;
    public GameObject Player;
    #endregion

    //HighscoreTable
    public GameObject HighScoreTable;
    public HighscoreTable highscoreTable;

    void Start()
    {
        HighScoreTable.SetActive(false);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        float radiants = 0;
        while (radiants == 0)
        {
            radiants = Random.Range(0, 5 * Mathf.PI);
            currentRadiants = radiants;
        }
        direction = new Vector2(Mathf.Cos(radiants), Mathf.Sin(radiants));
        direction.Normalize();
        direction *= startSpeed;
        rb.AddForce(direction);
    }


    void Update()
    {

       
    }

   

    private void OnCollisionEnter2D(Collision2D collision)
    {
      if(collision.collider.tag == "Player")
      {
            if (GameManager._GAME_MANAGER.isGodModeActive != true)
            {
                Destroy(Player);
                highscoreTable.AddHighscoreEntry(GameManager._GAME_MANAGER.score, PlayerPrefs.GetString("name"));
                HighScoreTable.SetActive(true);

            }
            
      }

      if (collision.collider.tag == "L")
      {
            //rb.AddForce(direction);
            GameManager._GAME_MANAGER.AddPoint();
            GameManager._GAME_MANAGER.num++;
            

        }

      if (collision.collider.tag == "R")
      {
            //rb.AddForce(direction);
            GameManager._GAME_MANAGER.AddPoint();
            GameManager._GAME_MANAGER.num++;
            
        }

      if (collision.collider.tag == "U")
      {
            //rb.AddForce(direction);
            GameManager._GAME_MANAGER.AddPoint();
            GameManager._GAME_MANAGER.num++;
           
        }

      if (collision.collider.tag == "D")
      {
            //rb.AddForce(direction);
            GameManager._GAME_MANAGER.AddPoint();
            GameManager._GAME_MANAGER.num++;
            
        }

      if (collision.collider.tag == "Wall")
      {
            
            
      }

    }

}
