﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class MainMenu : MonoBehaviour 
{
	//Text colors
	private Color32 normal   = new Color32 ( 150, 255, 255, 255 ); //Light cyan
	private Color32 selected = new Color32 (   0, 165, 255, 255 ); //Dark cyan

	//Animation information
	public GameObject [ ] waves;
	private const float ANIMATE_TIME = 0.2f;
	private const float DELAY_TIME = 1f / 3f;
	private bool allowInput = true;
	private enum MenuDestinations
	{
		None,
		StartGame,
		HowToPlay,
		Quit
	};

	/// <summary>
	/// Plays the starting animation.
	/// </summary>
	private void Start ( )
	{
		//Play animation
		AnimateTiles ( MenuDestinations.None );
	}

	/// <summary>
	/// Animates the tiles on screen.
	/// </summary>
	private void AnimateTiles ( MenuDestinations destination )
	{
		//Disable input
		allowInput = false;

		//Start animation
		Sequence s = DOTween.Sequence ( );
		for ( int i = 0; i < waves.Length; i++ )
		{
			foreach ( Transform child in waves [ i ].transform )
				s.Insert ( i * ( DELAY_TIME * ANIMATE_TIME ), child.DOPunchScale ( new Vector3 ( -1, -1, -1 ), ANIMATE_TIME, 1, 1 ) );
		}

		s.SetRecyclable ( )
			.OnComplete ( () =>
			{
				//Enable input
				allowInput = true;

				//Check destination
				switch ( destination )
				{
					case MenuDestinations.StartGame:
						Application.LoadLevel ( "Start Game" );
						break;
					case MenuDestinations.HowToPlay:
						Application.LoadLevel ( "Rules" );
						break;
					case MenuDestinations.Quit:
						Application.Quit ( );
						break;
				}
			} )
			.Play ( );
	}

	/// <summary>
	/// Highlights a button on the mouse hovering over it.
	/// </summary>
	public void OnMouseEnterButton ( Text t )
	{
		//Highlight button
		if ( allowInput )
			t.color = selected;
	}

	/// <summary>
	/// Unhighlights a button on the mouse no longer hovering over it.
	/// </summary>
	public void OnMouseExitButton ( Text t )
	{
		//Unhighlight button
		if ( allowInput )
			t.color = normal;
	}

	/// <summary>
	/// Start new game.
	/// </summary>
	public void OnNewGameClick ( )
	{
		//Load new game
		if ( allowInput )
		{
			SFXManager.instance.Click ( );
			MusicManager.instance.ChangeMusic ( AudioContext.AbilitySelection );
			AnimateTiles ( MenuDestinations.StartGame );
		}
	}

	/// <summary>
	/// Open rules screen
	/// </summary>
	public void OnHowToPlayClick ( )
	{
		//Load rules
		if ( allowInput )
		{
			SFXManager.instance.Click ( );
			MusicManager.instance.ChangeMusic ( AudioContext.HowToPlay );
			AnimateTiles ( MenuDestinations.HowToPlay );
		}
	}

	/// <summary>
	/// Quit game.
	/// </summary>
	public void OnQuitClick ( )
	{
		//Exit game
		if ( allowInput )
		{
			SFXManager.instance.Click ( );
			AnimateTiles ( MenuDestinations.Quit );
		}
	}
}
