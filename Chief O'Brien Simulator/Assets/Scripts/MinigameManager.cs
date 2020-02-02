using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameManager : MonoBehaviour
{
    [Header("Minigames")]
    public GameObject[] minigamePrefabs = new GameObject[5];
    public Transform positionToSpawnMinigame;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LostMinigame() {
        Debug.Log("Received lost minigame message.");
    }

    public void WonMinigame() {
        Debug.Log("Received won minigame message");
    }

    public void SpawnMinigame(int id) {
        GameObject minigame = (GameObject)Instantiate(minigamePrefabs[id], positionToSpawnMinigame.position, Quaternion.identity);
        minigame.transform.parent = this.transform;
    }
}
