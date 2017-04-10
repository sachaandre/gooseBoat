using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {

    Transform playerTransform;
    GameObject prefab;

    public Player()
    {
        prefab = Resources.Load("Player") as GameObject;
        playerTransform = prefab.GetComponent<Transform>();
        playerTransform.position = new Vector3(0, 0, 0);
        Object.Instantiate(prefab, playerTransform.position, playerTransform.rotation);
    }
}
