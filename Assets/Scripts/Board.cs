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
        this.islands = new Island[64];
        islandsPosition = new Vector3[64];
        CreateIslands();

    }

    public void CreateIslands()
    {
        Vector3 tmpVector;
        for (int i = 0; i < 64; i++)
        {
            this.islands[i] = new Island(i);
        }
    }

}
