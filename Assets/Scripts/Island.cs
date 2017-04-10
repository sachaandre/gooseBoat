using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island {

	public GameObject prefab;
	public Transform islandTransform;
	public int index;



	// Constructor
	public Island () {
		prefab = Resources.Load("ile") as GameObject;
		islandTransform = prefab.GetComponent<Transform> ();
		islandTransform.position = new Vector3 (0f, 0f, 0f);
		index = 0;
        islandTransform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }

	public void SetPosition(int i){
        float iRad = i*Mathf.Deg2Rad;
        float a = 24.5f;
        float b = 3.5f;
        float teta = Mathf.PI / 6 + iRad;

        //Formule spirale
        islandTransform.position = new Vector3((a*teta + b)* Mathf.Cos(a * teta + b), 0f, (a * teta + b) * Mathf.Sin(a * teta + b));
    }

	public void SetIndex(int i){
		index = i;
	}

    public void CreateIslands()
    {
        for (int i = 0; i < 64; i++)
        {
            SetPosition(i);
            SetIndex(i);
            MonoBehaviour.Instantiate(prefab, islandTransform.position, islandTransform.rotation);
        }
    }


}