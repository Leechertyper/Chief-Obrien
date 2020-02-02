using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineMinigameManager : MonoBehaviour
{
    public MinigameCameraManager camMan;

    // Start is called before the first frame update
    void Start()
    {
        camMan.SetMainCameraToThisMinigame();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoseMinigame() {
        Debug.Log("Lost minigame.");
        this.transform.parent.GetComponent<MinigameManager>().LostMinigame();
        ReturnControlToShip();
    }

    public void WinMinigame() {
        Debug.Log("Won minigame.");
        this.transform.parent.GetComponent<MinigameManager>().WonMinigame();
        ReturnControlToShip();
    }

    private void ReturnControlToShip() {
        camMan.ReturnMainCameraToShip();
        Destroy(gameObject);
    }

}
