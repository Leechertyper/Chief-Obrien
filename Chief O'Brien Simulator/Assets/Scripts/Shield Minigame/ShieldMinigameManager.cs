﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldMinigameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WinMinigame() {
        Debug.Log("Shield minigame handler received win message");
    }

    public void LoseMinigame() {
        Debug.Log("Shield minigame handler received loss message.");
    }
}
