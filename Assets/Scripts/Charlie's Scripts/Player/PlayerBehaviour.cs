using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    #region PlayerSpecs
    private Rigidbody2D rb;
    private Vector2 playerDirection;
    public float playerSpeed;
    #endregion
    #region ReflectThingys
    public GameObject rightThing;
    public GameObject leftThing;
    public GameObject upThing;
    public GameObject bottomThing;
    #endregion
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        #region DeactivateThingys
        rightThing.SetActive(false);
        leftThing.SetActive(false);
        upThing.SetActive(false);
        bottomThing.SetActive(false);
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        float directionY = Input.GetAxisRaw("Vertical");

        playerDirection = new Vector2(directionX, directionY).normalized;
        Debug.Log(playerDirection.y);
        Debug.Log(playerDirection.x);

        if(Input.GetMouseButton(0) && playerDirection.y == 1)
        {
            upThing.SetActive(true);
        }
        else
        {
            upThing.SetActive(false);
        }
        if (Input.GetMouseButton(0) && playerDirection.y == -1)
        {
            bottomThing.SetActive(true);
        }
        else
        {
            bottomThing.SetActive(false);
        }
        if (Input.GetMouseButton(0) && playerDirection.x == 1)
        {
            rightThing.SetActive(true);
        }
        else
        {
            rightThing.SetActive(false);
        }
        if (Input.GetMouseButton(0) && playerDirection.x == -1)
        {
            leftThing.SetActive(true);
        }
        else
        {
            leftThing.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(playerDirection.x * playerSpeed * Time.deltaTime, playerDirection.y * playerSpeed * Time.deltaTime);
    }
}
