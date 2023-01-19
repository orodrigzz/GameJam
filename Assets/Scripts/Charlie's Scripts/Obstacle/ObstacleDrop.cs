using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDrop : MonoBehaviour
{
    public GameObject[] powerUps;
    public int whatPowerUp;

    void Start()
    {
        whatPowerUp = Random.Range(0, powerUps.Length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ball"){
            Instantiate(powerUps[whatPowerUp], this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        
    }
}
