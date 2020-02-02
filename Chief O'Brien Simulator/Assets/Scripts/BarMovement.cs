using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BarMovement : MonoBehaviour
{
    public Transform weKillYou;
    public float moveSpeed;
    public float rateOfMovement = 10;
    // Start is called before the first frame update
    void Start()
    {
        if (weKillYou == null){
            Debug.LogError("Transform not set in Editor.");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 directionOfMovement = new Vector3 (rateOfMovement * Time.fixedDeltaTime,0,0);
        this.transform.Translate(directionOfMovement);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collided");
    
    }
}
