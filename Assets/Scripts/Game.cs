using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {

    private Board board;
    private Player player;
    private Dice dice;
    private int diceValue;
    private Text diceText;
    private GameObject diceTextObject;

    // Use this for initialization
    void Start () {
        dice = new Dice();
        board = new Board();
        player = new Player();
        diceTextObject = GameObject.Find("DiceValue");
        diceText = diceTextObject.GetComponent<Text>();
        diceValue = 0;
    }
	
	public void OnRollDiceClick()
    {
        dice.SetDiceValue();
        diceValue = dice.GetDiceValue();
        DisplayRollDice();  
        Debug.Log(diceValue);
    }

    public void DisplayRollDice()
    {
        diceText.text = "Dice Value : " + diceValue;
    }
}
