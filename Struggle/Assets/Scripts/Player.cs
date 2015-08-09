﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour 
{
	//Player's pieces
	public List < Piece > pieces = new List < Piece > ( );

	//Player's abilities
	public Ability [ ] abilities = new Ability [ 3 ];

	//Player's remaining time
	[ HideInInspector ]
	public float gameClock = 0;
	public bool clockIsActive = false;

	//Player's board game objects
	public Tile goal;
	public GameObject zapArea;
	public Tile [ ] zapTiles;

	//Player's HUD game objects
	public Text [ ] abilityNames;
	public Image [ ] abilityPieces;
	public Image [ ] p1NonagressionPieces;
	public Image [ ] p2NonagressionPieces;
	public Button [ ] abilityButtons;
	public GameObject [ ] descPanel;
	public Text [ ] desc;
	public Text gameClockDisplay;
	public Text prompt;
	public GameObject endButton;
	public Text endTurnText;
	public GameObject cancelButton;
	public Button acceptButton;

	/// <summary>
	/// Gets a player's piece by its color.
	/// </summary>
	public Piece GetPieceByColor ( PieceColor color )
	{
		//Find piece
		foreach ( Piece p in pieces )
			if ( p.color == color )
				return p;

		//Return first piece if the proper piece could not be found
		return pieces [ 0 ];
	}
}
