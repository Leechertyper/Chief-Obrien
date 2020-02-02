using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireRenderer : MonoBehaviour
{   
        public int[,] ennumeratedColourList = new int[6,3] { {1,2,3}, {2,1,3}, {1,3,2}, {2,3,1}, {3,1,2}, {3,2,1} };
        public int[] connectorColourList = new int[3];
        public int currentConnectorColour = 0;
        public LineRenderer connection;


        public Color[] colors = new Color[3];

    // Start is called before the first frame update
    void Start()
    {
        connectorColourList[0] = 1;
        connectorColourList[1] = 2;
        connectorColourList[2] = 3;
        /*ennumeratedColourList = { {1,2,3}, {2,1,3}, {1,3,2}, {2,3,1}, {3,1,2}, {3,2,1} };
        connectorColourList = ennumeratedColourList[Random.range(0,6)];
        currentConnectorColour = connectorColourList[0];*/
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown("a"))
        {
            MatchLeft();
        }
        else if (Input.GetKeyDown("w"))
        {
            MatchTop();
        }
        else if (Input.GetKeyDown("d"))
        {
            MatchRight();
        }
        
        /*
        if A pressed, attempt left connection
        if D pressed, attempt right connection
        if W pressed, attempt top connection
        if colours of connection and match location match, move to next colour in connectorColourList
            else game failed
        line renderer between connector base and match location
        */
    }
    public void MatchLeft()
    {
        if (connectorColourList[currentConnectorColour] == 1)
        {
            connection.SetColors(colors[0],colors[0]);
            connection.SetPosition(0, new Vector3(0.0f, -3.0f, 0.0f));
            currentConnectorColour++;
        }else{
            //YouDoneFuckedUp();
        }
    }
    public void MatchTop()
    {
        if (connectorColourList[currentConnectorColour] == 2)
        {
            connection.SetColors(colors[1],colors[1]);
            connection.SetPosition(1, new Vector3(0.0f, 3.0f, 0.0f));
            currentConnectorColour++;
           }else{
            //YouDoneFuckedUp();
        }
    }
    public void MatchRight()
    {
        if (connectorColourList[currentConnectorColour] == 3)
        {
            connection.SetColors(colors[1],colors[1]);
            connection.SetPosition(2, new Vector3(-3.0f, 0.0f, 0.0f));
            currentConnectorColour++;
        }else{
            //YouDoneFuckedUp();
        }
    }
}