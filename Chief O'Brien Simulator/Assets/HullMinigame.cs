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
    private float probabilityOfChangingDirection = 0.005f;
    private float timeSinceLastDirectionChange=0f;
    private float direction = 1f;
    private bool returning = false;
    private bool completed = false;
    // Start is called before the first frame update
    void Start()
    {
        missed = 0;
    }
    private void ChangeDirection(System.Random r)
    {
        if (timeSinceLastDirectionChange < Time.time && !returning)
        {
            if (Math.Abs(this.transform.position.x) > 5)
            {
                returning = true;
                print("returning");
                direction = direction * -1f;
            }
            float change = (float)(r.NextDouble());
            if ( probabilityOfChangingDirection >= change)
            {
                probabilityOfChangingDirection = 0.005f;
                timeSinceLastDirectionChange = Time.time+1f;

                direction = direction * -1f;
                timeSinceLastDirectionChange = timeSinceLastDirectionChange * -1f;
            }
            else
            {
                probabilityOfChangingDirection = probabilityOfChangingDirection*1.005f;
            }
        }
        else if(returning && Math.Abs(this.transform.position.x) < 5)
        {
            returning = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        void SpawnerMovement()
        {
            System.Random r = new System.Random();
            ChangeDirection(r);
            float movementChange = speed * (float)((r.NextDouble() * 3)) * direction * Time.deltaTime;
            gameObject.transform.position = new Vector2(transform.position.x + movementChange, transform.position.y);
        }
        void UpdateTimers()
        {
            timer -= Time.deltaTime;
            endtimer -= Time.deltaTime;
            if (timer <= 0f)
            {
                timer = 0.45f;
                GameObject go = Instantiate(prefab, gameObject.transform.position, Quaternion.identity);
                go.AddComponent<MetalMovement>();

            }
        }
        void CheckEndConditions()
        {
            if (endtimer <= 0)
            {
                Debug.Log("Success");
                completed = true;
            }
            else if (missed / 2 == 8)
            {
                Debug.Log("Failed");
                completed = true;
            }
            else
            {
                UpdateTimers();
            }
        }
        SpawnerMovement();
        if (!completed)
        {
            CheckEndConditions();
        }
        
    }
}
