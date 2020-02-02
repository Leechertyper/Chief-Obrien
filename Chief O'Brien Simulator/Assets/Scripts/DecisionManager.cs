using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebHandler;

public class DecisionManager : MonoBehaviour
{
    public float timer;
    public Request request;
    public int response = -1;

    public float voteWaitTime = 30f;

    // Start is called before the first frame update
    async void Start()
    {
        request = new Request();
        await request.GetRoom();
        print(request.json.room_id);
        await request.StartVote();
        timer = voteWaitTime;
    }

    // Update is called once per frame
    async void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f) {
            timer = voteWaitTime;
            response = await request.GetVote();
            if (response != -1) {
                await request.StartVote();
            }
        }
    }

    public int GetResponse() {
        return response;
    }

    public int GenerateMinigameID() {
        return Random.Range(0,2);
    }

    // await request.KillRoom();
}
