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
       

        if(Input.GetKey(KeyCode.Keypad8))
        {
            upThing.SetActive(true);
        }
        else
        {
            upThing.SetActive(false);
        }
        if (Input.GetKey(KeyCode.Keypad5))
        {
            bottomThing.SetActive(true);
        }
        else
        {
            bottomThing.SetActive(false);
        }
        if (Input.GetKey(KeyCode.Keypad6))
        {
            rightThing.SetActive(true);
        }
        else
        {
            rightThing.SetActive(false);
        }
        if (Input.GetKey(KeyCode.Keypad4))
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "ExtraPoints")
        {
            GameManager._GAME_MANAGER.ExtraPoints();
        }
        if (collision.collider.tag == "GodMode")
        {
            GameManager._GAME_MANAGER.GodMode();
        }
        if (collision.collider.tag == "SmallArena")
        {
            GameManager._GAME_MANAGER.SmallArena();
        }
    }
}
