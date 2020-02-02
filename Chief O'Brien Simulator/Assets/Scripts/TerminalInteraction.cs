using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalInteraction : MonoBehaviour
{

    [Header("Manager References")]
    public GameMaster gameMaster;
    public bool canCallManager = false;

    [Header("Collision References")]
    public Collider2D shadowCollider;
    public GameObject playerObjectCollided;

    [Header("Minigame Variables")]
    public int minigameID;
    public bool minigameReady;

    // Start is called before the first frame update
    void Start()
    {
        if (shadowCollider == null)
        {
            Debug.LogError("Shadow collidier not set in editor.");
        }
        if (gameMaster == null) {
            Debug.LogError("Game master not set in editor.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canCallManager && Input.GetAxisRaw("Jump") != 0) {
            CallManager();
        }

        if (minigameReady) {
            this.transform.GetComponent<SpriteRenderer>().color = Color.red;
        } else {
            this.transform.GetComponent<SpriteRenderer>().color = Color.blue;
        }

    }

    void CallManager() {
        gameMaster.SetupMinigame(this.minigameID);
        canCallManager = false;
        minigameReady = false;
    }

    public bool IsTerminalActive() {
        return this.minigameReady;
    }

    public void SetTerminalActive() {
        this.minigameReady = true;
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Player" && minigameReady)
        {
            Debug.Log(this.gameObject + " was touched by " + collision.gameObject);
            playerObjectCollided = collision.gameObject;
            canCallManager = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            Debug.Log(collision.gameObject + " stopped touching " + this.gameObject);
            playerObjectCollided = null;
            canCallManager = false;
        }
    }
}
