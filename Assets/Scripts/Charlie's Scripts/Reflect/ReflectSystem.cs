using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectSystem : MonoBehaviour
{
    #region
    private Rigidbody2D rb;
    public enum reflectPos { BOTTOM,UP,RIGHT,LEFT};
    public reflectPos refPos;
    public float impulse;
    Vector3 impulseDir;
    #endregion
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
           if(refPos == reflectPos.BOTTOM)
           {
                impulseDir = new Vector3(0, impulse * -1, 0);
                rb.AddForce(impulseDir, ForceMode2D.Impulse);
           }
           if (refPos == reflectPos.UP)
           {
                impulseDir = new Vector3(0, impulse * 1, 0);
                rb.AddForce(impulseDir, ForceMode2D.Impulse);
           }
           if (refPos == reflectPos.RIGHT)
           {
                impulseDir = new Vector3(0, impulse * 1, 0);
                rb.AddForce(impulseDir, ForceMode2D.Impulse);
           }
           if (refPos == reflectPos.LEFT)
           {
                impulseDir = new Vector3(0, impulse * 1, 0);
                rb.AddForce(impulseDir, ForceMode2D.Impulse);
           }
        }
    }
}
