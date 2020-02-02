using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameCameraManager : MonoBehaviour
{
    [Header("Target")]
    public Transform minigameCamTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMainCameraToThisMinigame() {
        CameraManager.instance.SetMinigameTransform(minigameCamTarget);
        CameraManager.instance.SetTargetToMinigame();
    }

    public void ReturnMainCameraToShip() {
        CameraManager.instance.SetTargetToPlayer();
    }
}
