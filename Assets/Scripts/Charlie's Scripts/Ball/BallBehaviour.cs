using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    #region BallParameters
    public float ballSpeed;
    private Rigidbody2D rb;
    #endregion



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = RandomVector(5f, -5f);
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
}
