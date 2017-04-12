using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {

    public Transform playerTransform;
    public GameObject prefab;

    public Player(string playerName, Vector3 islandPos)
    {
        prefab = GameObject.Find(playerName);
        /*prefab = Resources.Load("Player") as GameObject;
        Object.Instantiate(prefab, playerTransform.position, playerTransform.rotation)*/
        playerTransform = prefab.GetComponent<Transform>();
        SetPosition(islandPos);
    }

    public void SetPosition(Vector3 islandPos) {
        playerTransform.position = islandPos;
    }

    public Vector3 GetPosition()
    {
        return playerTransform.position;
    }

    public int CheckPlayerPresence(Vector3[] islandPos)
    {
        bool playerExist = false;
        int i = 0;

        while (!playerExist && i <= 63)
        {
            if (playerTransform.position == islandPos[i])
            {
                playerExist = true;
                return i;
            }
            else
            {
                i++;
            }
        };
        //ERROR NUMBER
        return i;
    }
}
