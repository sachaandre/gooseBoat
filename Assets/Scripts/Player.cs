using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {

    public Transform playerTransform;
    public GameObject prefab;

    public Player()
    {
        prefab = GameObject.Find("pirateships");
        /*prefab = Resources.Load("Player") as GameObject;
        
        Object.Instantiate(prefab, playerTransform.position, playerTransform.rotation)*/
        playerTransform = prefab.GetComponent<Transform>();
    }

    public void SetPosition(Vector3 islandPos) {
        playerTransform.position = islandPos;
    }

    public Vector3 GetPosition()
    {
        return playerTransform.position;
    }
}
