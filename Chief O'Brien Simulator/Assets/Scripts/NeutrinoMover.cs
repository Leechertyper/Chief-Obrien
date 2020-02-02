using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NeutrinoMover : MonoBehaviour
{
    private float nextPosition = 0f;
    private float initialY;
    public float speed;

    public GameObject Avatar;

    // Start is called before the first frame update
    void Start()
    {
        initialY = this.transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if( 0.1 >= Math.Abs(this.transform.position.y - nextPosition))
        {
            nextPosition = initialY + (float)UnityEngine.Random.Range(-3, 3);
        }
        else
        {
            this.transform.position = Vector2.Lerp(this.transform.position, new Vector2(this.transform.position.x, nextPosition), speed*Time.deltaTime);
        }

    }
}
