using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    public static CameraManager instance;

    [Header("Target References")]
    public Transform target;
    public Transform player;
    public Transform minigame;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) {
            instance = this;
            SetTargetToPlayer();
        } else {
            Debug.Log("Camera already set.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveCameraToTarget();
    }

    void MoveCameraToTarget() {
        float targetX = target.position.x;
        float targetY = target.position.y;
        this.transform.position = new Vector3 (targetX, targetY, this.transform.position.z);
    }

    public void SetTargetToPlayer() {
        target = player;
    }

    public void SetMinigameTransform(Transform _minigame) {
        minigame = _minigame;
    }

    public void SetTargetToMinigame() {
        if (minigame == null) {
            Debug.LogError("Minigame transform not set. Use SetMinigameTransform().");
        } else {
        target = minigame;
        }
    }
}
