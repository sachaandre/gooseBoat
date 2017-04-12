using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {

    //Variables d'instance
    private Board board;
    private Dice dice;

    //Variables Players
    private Player[] player;
    private Vector3[] playerPos;

    private Player currentPlayer;
    private int currentPlayerIndex = -1;
    private Vector3 currentPlayerPos;

    private Text playerText;
    private GameObject playerTextObject;

    //Variables de dé
    private int diceValue;
    private Text diceText;
    private GameObject diceTextObject;

    //Variables Position
    private int targetCase;
    private Vector3 targetPos;
    private int actualCase;
    private float step;
    private bool move;
    private System.Random rnd;

    private GameObject startButton;
    private GameObject rollDiceButton;

    private Text victoryText;
    private GameObject victoryTextObject;
    private GameObject background;

    public float speed = 5f;
    public int nbPlayer;

    

    // Use this for initialization
    void Start () {
        //Instanciation des différents objets
        dice = new Dice();
        board = new Board();
        player = new Player[3];
        playerPos = new Vector3[3];
        CreatePlayers();

        //Récuperer le Texte
        diceTextObject = GameObject.Find("DiceValueText");
        diceText = diceTextObject.GetComponent<Text>();

        playerTextObject = GameObject.Find("RoundText");
        playerText = playerTextObject.GetComponent<Text>();

        //Récupérer les éléments graphiques
        startButton = GameObject.Find("StartGameButton");
        rollDiceButton = GameObject.Find("RollDiceButton");
        victoryTextObject = GameObject.Find("VictoryText");
        victoryText = victoryTextObject.GetComponent<Text>();
        background = GameObject.Find("Background");

        //Activation / Desactivation Game Objects
        rollDiceButton.SetActive(false);
        victoryTextObject.SetActive(false);

        //Init diceValue
        diceValue = 0;

        //Init move
        move = false;
    }

    private void Update()
    {
        if (move)
        {
            currentPlayerPos = Vector3.MoveTowards(currentPlayerPos, targetPos, speed * Time.deltaTime);
            currentPlayer.prefab.transform.position = currentPlayerPos;

            currentPlayer.SetPosition(currentPlayerPos);
            rollDiceButton.SetActive(false);

            if(currentPlayerPos == targetPos)
            {
                move = false;
                rollDiceButton.SetActive(true);
            }
        }

        
    }

    /////////////////////////////////
    /////////////////////////////////

    public void OnRollDiceClick()
    {
        GameRound();
        RollDice();
        DisplayGUI();  
        MovePlayer();
        
    }

    private void DisplayGUI()
    {
        diceText.text = "Dice Value : " + diceValue;
        playerText.text = "Au tour de p" + (currentPlayerIndex + 1).ToString();
    }

    private void RollDice()
    {
        dice.SetDiceValue();
        diceValue = dice.GetDiceValue();
    }

    /////////////////////////////////
    /////////////////////////////////


    private void MovePlayer()
    {
        SetTargetCase();
        currentPlayerPos = currentPlayer.GetPosition();
        targetPos = board.islandsPosition[targetCase];
        move = true;  
    } 

    private void SetTargetCase()
    {
        actualCase = currentPlayer.CheckPlayerPresence(board.islandsPosition);
        targetCase = actualCase - diceValue;
        if (targetCase < 0)
        {
            targetCase = 0;
            currentPlayer.hasWon = true;
            CheckWinState();
            Debug.Log(currentPlayerIndex);
        }
    }

    private void CheckWinState()
    {
        for (int i = 0; i < nbPlayer-1; i++)
        {
            if (player[i].hasWon)
            {
                rollDiceButton.SetActive(false);
                victoryText.text = "Le gagnant est : p" + (i+1).ToString();
                victoryTextObject.SetActive(true);
                background.SetActive(true);
                startButton.SetActive(true);
                Reset();
            }
        }
    }

    private void Reset()
    {
        for (int k = 0; k < nbPlayer - 1; k++)
        {
            player[k].SetPosition(board.islandsPosition[63]);
        }
        currentPlayerIndex = 5;
    }
    /////////////////////////////////
    /////////////////////////////////

    private void CreatePlayers()
    {
        for (int i = 0; i < nbPlayer; i++)
        {
            string playerName = "p" + i.ToString();
            player[i] = new Player(playerName, board.islandsPosition[63]);
            playerPos[i] = player[i].GetPosition();
        }
    }

    /////////////////////////////////
    /////////////////////////////////

    private void GameRound()
    {
        switch (currentPlayerIndex)
        {
            case 0:
                currentPlayer = player[0];
                currentPlayerPos = playerPos[0];
                currentPlayerIndex += 1;
                break;
            case 1:
                currentPlayer = player[1];
                currentPlayerPos = playerPos[1];
                currentPlayerIndex += 1;
                break;
            case 2:
                currentPlayer = player[2];
                currentPlayerPos = playerPos[2];
                currentPlayerIndex = 0;
                break;
            /* case 3:
                currentPlayer = player[3];
                currentPlayerPos = playerPos[3];
                currentPlayerIndex = 0;
                break; */
            default:
                rnd = new System.Random();
                currentPlayerIndex = rnd.Next(0, nbPlayer - 1);
                currentPlayer = player[currentPlayerIndex];
                Debug.Log(currentPlayerIndex);
                break;
        }
       
    }

    ////////////////////////////////
    ////////////////////////////////

    public void OnClickStartGame()
    {
        if (currentPlayerIndex == -1)
        {
            GameRound();
            DisplayGUI();
            startButton.SetActive(false);
            victoryTextObject.SetActive(false);
            rollDiceButton.SetActive(true);
            background.SetActive(false);
        }
        
    }
}
