using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board
{
    public int numberOfIslands = 64;
    public Island[] islands;
    public Vector3[] islandsPosition;

    // Use this for initialization
    public Board()
    {
        islands = new Island[numberOfIslands];
        islandsPosition = new Vector3[numberOfIslands];
        CreateIslands();
    }

    public void CreateIslands()
    {
        for (int i = 0; i < numberOfIslands; i++)
        {
            islands[i] = new Island(i);
            islandsPosition[i] = islands[i].GetPosition(i);
            islands[i].prefab.name = "ile"+i.ToString()+" ";
            
        }
    }

}
