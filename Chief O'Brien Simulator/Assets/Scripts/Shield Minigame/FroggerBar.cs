using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FroggerBar : MonoBehaviour
{

    [Header("Movement")]
    public float movementSpeed;
    public bool moveRight;
    private int direction;

    [Header("Spawner Reference")]
    public BarSpawner spawner;

    // Start is called before the first frame update
    void Start()
    {
        if (moveRight)
        {
            direction = 1;
        } else
        {
            direction = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((Mathf.Abs(transform.position.x)) >= 15)
        {
            Debug.Log("Delete bar");
            Destroy(this.gameObject);
            spawner.SpawnBar();
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * direction * movementSpeed * Time.fixedDeltaTime);
    }
}
