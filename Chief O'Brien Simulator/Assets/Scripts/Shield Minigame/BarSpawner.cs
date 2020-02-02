using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarSpawner : MonoBehaviour
{
    public GameObject barPrefab;
    public Transform barContainer;

    // Start is called before the first frame update
    void Start()
    {
        SpawnBar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnBar()
    {
        GameObject spawnedBar = Instantiate(barPrefab, this.transform.position, Quaternion.identity);
        spawnedBar.GetComponent<FroggerBar>().spawner = this.GetComponent<BarSpawner>();
        spawnedBar.transform.parent = barContainer;
    }
}
