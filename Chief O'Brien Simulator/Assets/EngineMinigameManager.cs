using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineMinigameManager : MonoBehaviour
{
    [Header("Entities")]
    public Transform avatar;
    public Transform target;

    [Header("Game Variables")]
    public float distance;
    public float viableDistance;
    public bool isTouching;

    [Header("Timer Variables")]
    public float timeToLose;
    public float loseTimer;
    public float timeToWin;
    public float winTimer;

    // Start is called before the first frame update
    void Start()
    {
        viableDistance = (avatar.localScale.y / 2) + (target.localScale.y / 2);
        ResetLoseTimer();
        ResetWinTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTouching) {
            DecrementLoseTimer();
        } else {
            ResetLoseTimer();
            DecrementWinTimer();
        }
    }

    void FixedUpdate() {
        isTouching = IsAvatarCloseEnoughToTarget();
    }

    bool IsAvatarCloseEnoughToTarget() {
        distance = Mathf.Abs(avatar.position.y - target.position.y);
        //Debug.Log(distance);
        if (distance <= viableDistance) {
            return true;
        } else {
            return false;
        }
    }

    void DecrementLoseTimer() {
        loseTimer -= Time.deltaTime;
        if (loseTimer <= 0) {
            LoseMinigame();
        }
    }

    void DecrementWinTimer() {
        winTimer -= Time.deltaTime;
        if (winTimer <= 0) {
            WinMinigame();
        }
    }

    void ResetLoseTimer() {
        loseTimer = timeToLose;
    }

    void ResetWinTimer() {
        winTimer = timeToWin;
    }

    void LoseMinigame() {
        Debug.Log("Lost minigame.");
    }

    void WinMinigame() {
        Debug.Log("Won minigame.");
    }

}
