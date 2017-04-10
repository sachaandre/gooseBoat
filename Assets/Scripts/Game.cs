using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    private Board board;
    private Player player;

	// Use this for initialization
	void Start () {
        board = new Board();
        player = new Player();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
