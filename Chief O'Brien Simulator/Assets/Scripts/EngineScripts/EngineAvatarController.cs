using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EngineAvatarController : MonoBehaviour
{
    public Rigidbody2D player_physics;
    public bool allow_infinite_jumping = true;
    public float jump_force;
    public Transform neutrino;
    private Boolean lostContact = false;
    private Boolean gameComplete = false;
    private float endTime = 20000000f;
    private float timer = 20000000f;
    public EngineMinigameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        GameStart();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            player_physics.AddForce(new Vector2(0, 1) * jump_force);
        }
    }

    void FixedUpdate()
    {
        if (!gameComplete)
        {
            float currTime = Time.time;
            if (Math.Abs(neutrino.position.y - this.transform.position.y) >= .95f && !lostContact)
            {
                timer = currTime + 3f;
                lostContact = true;
            }
            if (Math.Abs(neutrino.position.y - this.transform.position.y) <= .95f)
            {
                lostContact = false;
                timer = currTime + 10f;
            }

            if (currTime > endTime)
            {
                gameComplete = true;
                manager.WinMinigame();
            }
            else if (currTime > timer)
            {
                gameComplete = true;
                manager.LoseMinigame();
            }
        }
    }

    public void GameStart()
    {
        float currTime = Time.time;
        endTime = currTime + 10f;
        timer = currTime + 11f;
    }

}
