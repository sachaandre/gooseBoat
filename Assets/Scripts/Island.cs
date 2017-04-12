using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island
{

    public GameObject prefab;
    public Transform islandTransform;
    public int index;
    public Vector3[] islandPosition;
    public GameObject bubule;


    // Constructor
    public Island(int i)
    {

        prefab = Resources.Load("ile") as GameObject;
        bubule = Resources.Load("bubule") as GameObject;
        islandTransform = prefab.GetComponent<Transform>();
        index = i;
        SetPosition(index);
        SetBubulePosition(index - 0.5f);
        islandTransform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        MonoBehaviour.Instantiate(prefab, islandTransform.position, islandTransform.rotation);
        MonoBehaviour.Instantiate(bubule, bubule.transform.position, bubule.transform.rotation);
        

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

    public void SetBubulePosition(float i)
    {
        float iRad = i * Mathf.Deg2Rad;
        float a = 24.5f;
        float b = 3.5f;
        float teta = Mathf.PI / 6 + iRad;
        bubule.transform.position = new Vector3((a * teta + b) * Mathf.Cos(a * teta + b), 0f, (a * teta + b) * Mathf.Sin(a * teta + b));
    }

    public Vector3 GetPosition(int i)
    {

        //Formule spirale
        return this.islandTransform.position;
    }



}