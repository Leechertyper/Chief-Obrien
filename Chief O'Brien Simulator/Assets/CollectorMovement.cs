using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorMovement : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.45f;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        gameObject.transform.position = new Vector2 (transform.position.x + (h*speed), transform.position.y);

    }
}
