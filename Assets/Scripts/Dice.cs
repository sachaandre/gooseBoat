using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Dice {
    public int diceValue;
    private System.Random rnd;

    public void SetDiceValue()
    {
        rnd = new System.Random();
        diceValue = rnd.Next(1, 7);
    }

    public int GetDiceValue()
    {
        return diceValue;
    }

}

