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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        float radiants = 0;      
        while (radiants == 0)
        {
            radiants = Random.Range(0, 2 * Mathf.PI);
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

    private Vector2 RandomVector(float min, float max)
    {
        var x = Random.Range(min, max);
        var y = Random.Range(min, max);

        return new Vector2(x, y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      if(collision.collider.tag == "Player")
      {
            Destroy(Player);
      }

      if (collision.collider.tag == "L")
      {
            rb.AddForce(direction);
            GameManager._GAME_MANAGER.AddPoint();
            GameManager._GAME_MANAGER.num++;
      }

      if (collision.collider.tag == "R")
      {
            rb.AddForce(direction);
            GameManager._GAME_MANAGER.AddPoint();
            GameManager._GAME_MANAGER.num++;
      }

      if (collision.collider.tag == "U")
      {
            rb.AddForce(direction);
            GameManager._GAME_MANAGER.AddPoint();
            GameManager._GAME_MANAGER.num++;
      }

      if (collision.collider.tag == "D")
      {
            rb.AddForce(direction);
            GameManager._GAME_MANAGER.AddPoint();
            GameManager._GAME_MANAGER.num++;
      }

      if (collision.collider.tag == "Wall")
      {

      }

    }

}
