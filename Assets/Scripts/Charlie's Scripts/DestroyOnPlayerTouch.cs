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
            if (animator != null)
            {
                animator.SetTrigger("Picked");
                GameManager._GAME_MANAGER.extraPointsGiven = false;
                Destroy(this.gameObject, 0.43f);
            }
            if(animator == null)
            {
                GameManager._GAME_MANAGER.extraPointsGiven = false;
                Destroy(this.gameObject);
            }
            
        }

    }
}
