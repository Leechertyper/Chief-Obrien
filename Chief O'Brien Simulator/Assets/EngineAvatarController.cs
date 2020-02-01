using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineAvatarController : MonoBehaviour
{
    public Rigidbody2D player_physics;
    public bool allow_infinite_jumping = true;
    public float jump_force;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            player_physics.AddForce(new Vector2(0, 1) * jump_force);
        }
    }
}
