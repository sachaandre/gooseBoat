using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board {

	private Island island;

	// Use this for initialization
	public Board () {
		island = new Island ();
		island.CreateIslands ();
	}

}
