using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorMovement : MonoBehaviour
{
    public float speed;
    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        gameObject.transform.position = new Vector2 (transform.position.x + (h*speed)*Time.deltaTime, transform.position.y);

    }
    private void OnTriggerEnter2D(Collider2D c){
        source.Play();
    }

}
