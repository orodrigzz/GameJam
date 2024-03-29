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
    public Animator animator;
    #endregion

    #region SoftIA
    public bool isAwake;
    public Transform player;
    public GameObject Player;
    #endregion

    //HighscoreTable
    public GameObject HighScoreTable;
    public HighScoreLogic highscoreTable;

    public AudioSource dead;
    public AudioSource contramuro;
    public AudioSource contraplayer;
    void Start()
    {
        HighScoreTable.SetActive(false);
        Time.timeScale = 0f;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
      if(collision.collider.tag == "Player")
      {
            if (GameManager._GAME_MANAGER.isGodModeActive != true)
            {
                Time.timeScale = 0f;
                dead.Play();
                Destroy(Player);
                highscoreTable.AddHighscoreEntry(GameManager._GAME_MANAGER.score, PlayerPrefs.GetString("name"));
                HighScoreTable.SetActive(true);
            }
      }

      if (collision.collider.tag == "L")
      {
            contraplayer.Play();
            //rb.AddForce(direction);
            GameManager._GAME_MANAGER.AddPoint();
            GameManager._GAME_MANAGER.num++;
            animator.SetTrigger("Hit");
            animator.ResetTrigger("isMoving");

        }

      if (collision.collider.tag == "R")
      {
            //rb.AddForce(direction);
            contraplayer.Play();
            GameManager._GAME_MANAGER.AddPoint();
            GameManager._GAME_MANAGER.num++;
            animator.SetTrigger("Hit");
            animator.ResetTrigger("isMoving");

        }

      if (collision.collider.tag == "U")
      {
            //rb.AddForce(direction);
            contraplayer.Play();
            GameManager._GAME_MANAGER.AddPoint();
            GameManager._GAME_MANAGER.num++;
            animator.SetTrigger("Hit");
            animator.ResetTrigger("isMoving");

        }

        if (collision.collider.tag == "D")
        {
            //rb.AddForce(direction);
            contraplayer.Play();
            GameManager._GAME_MANAGER.AddPoint();
            GameManager._GAME_MANAGER.num++;
            animator.SetTrigger("Hit");
            animator.ResetTrigger("isMoving");

        }

      if (collision.collider.tag == "Wall")
      {
            contramuro.Play();

        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "L")
        {
            //rb.AddForce(direction);

           
            animator.ResetTrigger("Hit");
            animator.SetTrigger("isMoving");
        }

        if (collision.collider.tag == "R")
        {
            //rb.AddForce(direction);

            animator.ResetTrigger("Hit");
            animator.SetTrigger("isMoving");

        }

        if (collision.collider.tag == "U")
        {
            //rb.AddForce(direction);

            animator.ResetTrigger("Hit");
            animator.SetTrigger("isMoving");
        }

        if (collision.collider.tag == "D")
        {
            //rb.AddForce(direction);

            
            animator.ResetTrigger("Hit");
            animator.SetTrigger("isMoving");
        }
    }

}
