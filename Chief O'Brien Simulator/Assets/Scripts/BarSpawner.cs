using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarSpawner : MonoBehaviour
{
    public bool isGoingLeft;
    public GameObject barPrefab;
    public GameObject hold;
    public float localMovementSpeed;

    // Start is called before the first frame update
    void Start()
    {       
    
        SpawnBar();
    }
    public void SpawnBar()
    {
        hold = (GameObject) Instantiate(barPrefab,gameObject.transform.position,Quaternion.identity);
        if (isGoingLeft)
        {
            localMovementSpeed = Mathf.Abs(barPrefab.gameObject.GetComponent<BarMovement>().rateOfMovement);
        }else{
            localMovementSpeed = -1 * Mathf.Abs(barPrefab.gameObject.GetComponent<BarMovement>().rateOfMovement);
        }   
        hold.transform.GetComponent<BarMovement>().rateOfMovement = localMovementSpeed;
    }    
}