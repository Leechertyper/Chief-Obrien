using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HullMinigame : MonoBehaviour
{
    public GameObject prefab;
    public float speed;
    public int missed;
    private float timer = 2.0f;
    private float endtimer = 15.0f;
    // Start is called before the first frame update
    void Start()
    {
        missed = 0;
        speed = 0.015f;
    }

    // Update is called once per frame
    void Update()
    {
        System.Random r = new System.Random();
        if(gameObject.transform.position.x >=7 || gameObject.transform.position.x <=-7){
            speed = speed * -1;
        }
        gameObject.transform.position = new Vector2(transform.position.x + speed*(float)((r.NextDouble()*6.35)-3.0), transform.position.y);
        timer -= Time.deltaTime;
        endtimer -= Time.deltaTime;
        if (timer <= 0){
            timer = 0.45f;
            GameObject go = Instantiate(prefab, gameObject.transform.position, Quaternion.identity);
            go.AddComponent<MetalMovement>();

        }
        if(missed/2 == 8){
            Debug.Log("Failed");
        return;
        }
        if(endtimer <= 0){
            Debug.Log("Success");
        return;
        }
    }
}
