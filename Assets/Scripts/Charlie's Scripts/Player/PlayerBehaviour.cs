using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    #region PlayerSpecs
    private Rigidbody2D rb;
    private Vector2 playerDirection;
    public float playerSpeed;
    SpriteRenderer sprite;
    public Animator animator;
    float lastPlayerDirectionX;
    float lastPlayerDirectionY;
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
        sprite = GetComponent<SpriteRenderer>();
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
        lastPlayerDirectionX = playerDirection.x;
        lastPlayerDirectionY = playerDirection.y;

        animator.SetFloat("DirectionX", playerDirection.x);
        animator.SetFloat("DirectionY", playerDirection.y);
        if(playerDirection.x < 0 || playerDirection.x > 0 || playerDirection.y < 0|| playerDirection.y > 0)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        if (Input.GetKey(KeyCode.Keypad8))
        {
            upThing.SetActive(true);
            animator.SetBool("Back", true);
        }
        else
        {
            upThing.SetActive(false);
            animator.SetBool("Back", false);

        }
        if (Input.GetKey(KeyCode.Keypad5))
        {
            bottomThing.SetActive(true);
            animator.SetBool("Front", true);

        }
        else
        {
            bottomThing.SetActive(false);
            animator.SetBool("Front", false);
        }
        if (Input.GetKey(KeyCode.Keypad6))
        {
            rightThing.SetActive(true);
            animator.SetBool("Right", true);

        }
        else
        {
            rightThing.SetActive(false);
            animator.SetBool("Right", false);
        }
        if (Input.GetKey(KeyCode.Keypad4))
        {
            leftThing.SetActive(true);
            animator.SetBool("Left", true);
        }
        else
        {
            leftThing.SetActive(false);
            animator.SetBool("Left", false);
        }
        if (GameManager._GAME_MANAGER.isGodModeActive)
        {
            sprite.color = new Color(0,255,255);
        }
        if (GameManager._GAME_MANAGER.isGodModeActive == false)
        {
            sprite.color = new Color(255, 255, 255);
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
