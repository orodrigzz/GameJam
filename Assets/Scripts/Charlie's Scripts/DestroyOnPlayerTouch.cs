using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnPlayerTouch : MonoBehaviour
{
    public Animator animator;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            animator.SetTrigger("Picked");
            Destroy(this.gameObject, 0.43f);
        }
    }
}
