using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalMovement : MonoBehaviour
{
    public float speed;
    // Update is called once per frame
    void Start(){
        
    }
    void Update()
    {
        gameObject.transform.position = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y + speed*Time.deltaTime);
        if (gameObject.transform.position.y > 8){
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D c){
        if(c.gameObject.tag == "HULL"){
            GameObject go = GameObject.Find("Spawner");
            HullMinigame cs = go.GetComponent<HullMinigame>();
            cs.missed += 1;
        }

        Destroy(gameObject);
    }

}
