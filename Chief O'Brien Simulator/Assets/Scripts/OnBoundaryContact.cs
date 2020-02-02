using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class OnBoundaryContact : MonoBehaviour
{
    public BarSpawner ParentBarSpawner;
    public bool isGoingLeft; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x >= 10)
        {
            Destroy(this.gameObject);
            ParentBarSpawner.SpawnBar();
        }        
    }

}
