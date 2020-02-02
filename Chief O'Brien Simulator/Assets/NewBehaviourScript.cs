using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebHandler;
public class NewBehaviourScript : MonoBehaviour
{
    public float timer;
    public Request request;
    public int response;
    // Start is called before the first frame update
    async void Start()
    {
        request = new Request();
        await request.GetRoom();
        print(request.json.token);
        await request.StartVote();
        timer = 30f;
    }

    // Update is called once per frame
    async void Update()
    {
        timer -=Time.deltaTime;
        if (timer <= 0f){
            timer = 30f;
            response = await request.GetVote();
            print(response);
            if (response != -1){
                await request.StartVote();
            }
        }

    }
}
