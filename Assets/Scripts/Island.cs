using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island
{

    public GameObject prefab;
    public Transform islandTransform;
    public int index;
    public Vector3[] islandPosition;


    // Constructor
    public Island(int i)
    {

        prefab = Resources.Load("ile") as GameObject;
        islandTransform = prefab.GetComponent<Transform>();
        index = i;
        this.SetPosition(this.index);
        islandTransform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        MonoBehaviour.Instantiate(prefab, islandTransform.position, islandTransform.rotation);

    }

    public void SetPosition(int i)
    {
        float iRad = i * Mathf.Deg2Rad;
        float a = 24.5f;
        float b = 3.5f;
        float teta = Mathf.PI / 6 + iRad;

        //Formule spirale
        islandTransform.position = new Vector3((a * teta + b) * Mathf.Cos(a * teta + b), 0f, (a * teta + b) * Mathf.Sin(a * teta + b));
    }

    public Vector3 GetPosition(int i)
    {

        //Formule spirale
        return this.islandTransform.position;
    }



}