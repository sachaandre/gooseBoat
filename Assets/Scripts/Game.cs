using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {

    //Variables d'instance
    private Board board;
    private Player player;
    private Dice dice;

    //Variables de dé
    private int diceValue;
    private Text diceText;
    private GameObject diceTextObject;

    //Variables Position
    private Vector3 pyPos;
    private int targetCase;
    private Vector3 targetPos;
    private int actualCase;
    private float step;
    private bool move;

    public float speed = 5f;
    

    // Use this for initialization
    void Start () {


        //Instanciation des différents objets
        dice = new Dice();
        board = new Board();
        player = new Player();
        
        //Met le joueur sur l'ile 0
        player.SetPosition(board.islandsPosition[63]);

        //Récuperer le Texte
        diceTextObject = GameObject.Find("DiceValue");
        diceText = diceTextObject.GetComponent<Text>();

        //Init diceValue
        diceValue = 0;
        
        //Init move
        move = false;
    }

    private void Update()
    {
        if (move)
        {
            pyPos = player.GetPosition();
            Debug.Log(targetCase);
            Debug.Log(targetPos == pyPos);
            pyPos = Vector3.MoveTowards(pyPos, targetPos, speed * Time.deltaTime);
            //player.playerTransform.position = new Vector3(player.playerTransform.position.x, player.playerTransform.position.y, player.playerTransform.position.z+1.0f*Time.deltaTime*speed);
            player.prefab.transform.position = pyPos;

            player.SetPosition(pyPos); 

            if(player.GetPosition() == targetPos)
            {
                Debug.Log("toto");
                move = false;
            }
        }
    }


    public void OnRollDiceClick()
    {
        RollDice();
        DisplayRollDice();  
        MovePlayer();
        
    }

    private void DisplayRollDice()
    {
        diceText.text = "Dice Value : " + diceValue;
    }

    private void RollDice()
    {
        dice.SetDiceValue();
        diceValue = dice.GetDiceValue();
    }

    private void MovePlayer()
    {
        actualCase = CheckPlayerPresence();
        pyPos = player.GetPosition();
        targetCase = actualCase-diceValue;
        targetPos = board.islandsPosition[targetCase];
        Debug.Log(move);
        move = true;
        
    }

    private int CheckPlayerPresence()
    {
        bool playerExist = false;
        int i = 0;

        while (!playerExist && i <= 63)
        {
            if (pyPos == board.islandsPosition[i])
            {
                playerExist = true;
                return i;
            }
            else
            {
                i++;
            }
        } ;
        //ERROR NUMBER
        return i;
    }
}
