using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {

    private Board board;
	private GameObject player;
    private Dice dice;
	private int diceValue;
	private int diceValueIncrement;
    private Text diceText;
    private GameObject diceTextObject;
	private GameObject islandTarget;
	private Vector3 islandVector;

	public float speed  = 15.0f; // move speed
	public bool move = false;



    // Use this for initialization
    void Start () {
        dice = new Dice();
//        board = new Board();
		player = GameObject.Find("Player");
        diceTextObject = GameObject.Find("DiceValue");
        diceText = diceTextObject.GetComponent<Text>();
        diceValue = 0;
		diceValueIncrement = 0;
		islandTarget = GameObject.Find("1");


    }
	void Update()
	{
		if (move)
		{
			Vector3 islandFrom = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z);
			Vector3 islandTo = new Vector3 (islandTarget.transform.position.x, islandTarget.transform.position.y, islandTarget.transform.position.z);
			player.transform.position = Vector3.MoveTowards(islandFrom, islandTo, speed*Time.deltaTime);
		}

		if (Input.GetButtonDown ("Jump")) {
			move = true;
		}
	}
	
	public void OnRollDiceClick()
    {
        dice.SetDiceValue();
        diceValue = dice.GetDiceValue();
		DisplayRollDice (); 
		diceValueIncrement += diceValue;
		islandTarget = GameObject.Find(diceValueIncrement.ToString());

		Vector3 islandFrom = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z);
		Vector3 islandTo = new Vector3 (islandTarget.transform.position.x, islandTarget.transform.position.y, islandTarget.transform.position.z);
		player.transform.position = Vector3.MoveTowards(islandFrom, islandTo, speed*Time.deltaTime);

		if (islandFrom == islandTo) {
			move = true;
		}


		Debug.Log ("Valeur dice = " + diceValue);
		Debug.Log ("Target ile = " + islandTarget);

		Debug.Log ("posFrom = " + islandFrom);
		Debug.Log ("posTo = " + islandTo);
    }

    public void DisplayRollDice()
    {
        diceText.text = "Dice Value : " + diceValue;
    }
}
