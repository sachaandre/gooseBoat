using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    private int diceValue;
    private System.Random rnd;
    private Text diceText;

    public void Awake()
    {
        diceText = GetComponent<Text>();
    } 
    
    public void GenerateRollDice()
    {
        diceValue = GenerateValue();
        diceText.text = "Dice Value : " + diceValue;

    }

    private int GenerateValue()
    {
        rnd = new System.Random();
        diceValue = rnd.Next(1, 7);
        return diceValue;
    }

}

