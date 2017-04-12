using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board
{

    public Island[] islands;
    public Vector3[] islandsPosition;

    // Use this for initialization
    public Board()
    {
        islands = new Island[64];
        islandsPosition = new Vector3[64];
        CreateIslands();
    }

    public void CreateIslands()
    {
        for (int i = 0; i < 64; i++)
        {
            islands[i] = new Island(i);
            islandsPosition[i] = islands[i].GetPosition(i);
            islands[i].prefab.name = "ile"+i.ToString()+" ";
            
        }
    }

}
