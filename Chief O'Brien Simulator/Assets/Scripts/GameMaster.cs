using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [Header("Managers")]
    public MinigameManager minigameMan;

    [Header("Scene References")]
    public GameObject mainSceneContainer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadMinigame(int id) {
        minigameMan.SpawnMinigame(id);
    }

    public void SetupMinigame(int minigameID) {
        Debug.Log("Received minigame ID: " + minigameID);
        LoadMinigame(minigameID);
    }

    // Debug
    public void ReceiveCall(GameObject caller) {
        Debug.Log("Received message from " + caller);
    }
}
