using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOscar : MonoBehaviour
{
    public GameObject Circle;
    private int num= 0;

    public float x;
    public float y;
    Vector2 randomPos;

    void Update()
    {
        x = Random.Range(-10, 10);
        y = Random.Range(-5, 5);
        randomPos = new Vector2(x, y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
           num++;
        }

        if (num == 5)
        {
            Instantiate(Circle, randomPos, Quaternion.identity);
            num = 0;
        }
    }
}
