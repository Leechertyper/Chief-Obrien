using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [Header("Managers")]
    public MinigameManager minigameMan;
    public DecisionManager decisionMan;

    [Header("Terminals")]
    public TerminalInteraction[] terminals = new TerminalInteraction[5];

    [Header("Scene References")]
    public GameObject mainSceneContainer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int responseID = decisionMan.GetResponse();
        Debug.Log(responseID);
        if (responseID != -1) {
            ActivateTerminal(responseID);
        }
    }

    public void ActivateTerminal(int id) {
        if (terminals[id].IsTerminalActive()) {
            //Debug.Log("Terminal already active. ID: " + id);
        } else {
            Debug.Log("Terminal not active. Activating.");
            terminals[id].SetTerminalActive();
        }
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
