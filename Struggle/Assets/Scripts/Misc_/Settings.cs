using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour 
{
	//Checks for the start of the game
	private static bool GameStart = true;

	/// <summary>
	/// This setting determines the layout of the board.
	/// </summary>
	public static bool LayoutIsVertical;

	/// <summary>
	/// This setting determines the volume of the music.
	/// </summary>
	public static float MusicVolume;

	/// <summary>
	/// This setting determines the volume of the sound effects.
	/// </summary>
	public static float SoundVolume;

	/// <summary>
	/// This setting determines the start time for each player's game clock.
	/// </summary>
	public static int GameClock;

	/// <summary>
	/// This save data determines which player's turn it is.
	/// </summary>
	public static bool SaveDataIsP1Turn;

	/// <summary>
	/// This save data determines player 1's abilities. X is the ability ID, Y is if it is active, and Z is the piece it's attached to.
	/// </summary>
	public static Vector3 [ ] SaveDataP1Abilities = new Vector3 [ 3 ];

	/// <summary>
	/// This save data determines player 2's abilities. X is the ability ID, Y is if it is active, and Z is the piece it's attached to.
	/// </summary>
	public static Vector3 [ ] SaveDataP2Abilities = new Vector3 [ 3 ];

	/// <summary>
	/// This save data determines the location of all of the players' pieces on the board. X is the player, Y is the piece color, and Z is the tile ID.
	/// </summary>
	public static Vector3 [ ] SaveDataPieces = new Vector3 [ 12 ];

	/// <summary>
	/// This save data determines the pieces player 1 sacrificed.
	/// </summary>
	public static int SaveDataP1Sacrifice;

	/// <summary>
	/// This save data determines the pieces player 2 sacrificed.
	/// </summary>
	public static int SaveDataP2Sacrifice;

	/// <summary>
	/// This save data determines the game clock setting of the save game.
	/// </summary>
	public static int SaveDataGameClock;

	/// <summary>
	/// This save data determines the time remaining on player 1's game clock.
	/// </summary>
	public static float SaveDataP1GameClock;

	/// <summary>
	/// This save data determines the time remaining on player 2's game clock.
	/// </summary>
	public static float SaveDataP2GameClock;

	/// <summary>
	/// Initialize the settings at the start of the game.
	/// </summary>
	private void Awake ( )
	{
		//Check for game start up
		if ( GameStart )
		{
			//Check for board layout
			if ( PlayerPrefs.HasKey ( "boardLayout" ) )
			{
				//Load layout setting
				LayoutIsVertical = PlayerPrefsX.GetBool ( "boardLayout" );
			}
			else
			{
				//Set layout setting
				LayoutIsVertical = false;
				PlayerPrefsX.SetBool ( "boardLayout", LayoutIsVertical );
			}

			//Check for music volume
			if ( PlayerPrefs.HasKey ( "musicVolume" ) )
			{
				//Load music volume
				MusicVolume = PlayerPrefs.GetFloat ( "musicVolume" );
			}
			else
			{
				//Set music volume
				MusicVolume = 1;
				PlayerPrefs.SetFloat ( "musicVolume", MusicVolume );
			}

			//Set music volume
			MusicManager.instance.UpdateMusicVolume ( );

			//Check for sound volume
			if ( PlayerPrefs.HasKey ( "soundVolume" ) )
			{
				//Load sound volume
				SoundVolume = PlayerPrefs.GetFloat ( "soundVolume" );
			}
			else
			{
				//Set sound volume
				SoundVolume = 1;
				PlayerPrefs.SetFloat ( "soundVolume", SoundVolume );
			}

			//Set SFX volume
			SFXManager.instance.UpdateSFXVolume ( );

			//Check for game clock setting
			if ( PlayerPrefs.HasKey ( "gameClock" ) )
			{
				//Load game clock setting
				GameClock = PlayerPrefs.GetInt ( "gameClock" );
			}
			else
			{
				//Set game clock setting
				GameClock = 0;
				PlayerPrefs.SetInt ( "gameClock", GameClock );
			}

			//Check for player's turn save data
			if ( PlayerPrefs.HasKey ( "playerTurn" ) )
			{
				//Load save data
				SaveDataIsP1Turn = PlayerPrefsX.GetBool ( "playerTurn" );
			}
			else
			{
				//Set empty save data
				SaveDataIsP1Turn = true;
				PlayerPrefsX.SetBool ( "playerTurn", SaveDataIsP1Turn );
			}

			//Check for player 1 ability save data
			if ( PlayerPrefs.HasKey ( "player1Abilities" ) )
			{
				//Load save data
				SaveDataP1Abilities = PlayerPrefsX.GetVector3Array ( "player1Abilities" );
			}
			else
			{
				//Set empty save data
				for ( int i = 0; i < SaveDataP1Abilities.Length; i++ )
					SaveDataP1Abilities [ i ] = Vector3.zero;
				PlayerPrefsX.SetVector3Array ( "player1Abilities", SaveDataP1Abilities );
			}

			//Check for player 2 ability save data
			if ( PlayerPrefs.HasKey ( "player2Abilities" ) )
			{
				//Load save data
				SaveDataP2Abilities = PlayerPrefsX.GetVector3Array ( "player2Abilities" );
			}
			else
			{
				//Set empty save data
				for ( int i = 0; i < SaveDataP2Abilities.Length; i++ )
					SaveDataP2Abilities [ i ] = Vector3.zero;
				PlayerPrefsX.SetVector3Array ( "player2Abilities", SaveDataP2Abilities );
			}

			//Check for piece position save data
			if ( PlayerPrefs.HasKey ( "pieces" ) )
			{
				//Load save data
				SaveDataPieces = PlayerPrefsX.GetVector3Array ( "pieces" );
			}
			else
			{
				//Set empty save data
				for ( int i = 0; i < SaveDataPieces.Length; i++ )
					SaveDataPieces [ i ] = Vector3.zero;
				PlayerPrefsX.SetVector3Array ( "pieces", SaveDataPieces );
			}

			//Check for player 1's sacrificed pieces save data
			if ( PlayerPrefs.HasKey ( "player1Sacrifice" ) )
			{
				//Load save data
				SaveDataP1Sacrifice = PlayerPrefs.GetInt ( "player1Sacrifice", 0 );
			}
			else
			{
				//Set empty save data
				SaveDataP1Sacrifice = 0;
				PlayerPrefs.SetInt ( "player1Sacrifice", SaveDataP1Sacrifice );
			}

			//Check for player 2's sacrificed pieces save data
			if ( PlayerPrefs.HasKey ( "player2Sacrifice" ) )
			{
				//Load save data
				SaveDataP2Sacrifice = PlayerPrefs.GetInt ( "player2Sacrifice", 0 );
			}
			else
			{
				//Set empty save data
				SaveDataP2Sacrifice = 0;
				PlayerPrefs.SetInt ( "player2Sacrifice", SaveDataP2Sacrifice );
			}

			//Check for game clock setting save data
			if ( PlayerPrefs.HasKey ( "saveGameClock" ) )
			{
				//Load save data
				SaveDataGameClock = PlayerPrefs.GetInt ( "saveGameClock" );
			}
			else
			{
				//Set empty save data
				SaveDataGameClock = 0;
				PlayerPrefs.SetInt ( "saveGameClock", SaveDataGameClock );
			}

			//Check of player 1 game clock save data
			if ( PlayerPrefs.HasKey ( "player1GameClock" ) )
			{
				//Load save data
				SaveDataP1GameClock = PlayerPrefs.GetFloat ( "player1GameClock" );
			}
			else
			{
				//Set empty save data
				SaveDataP1GameClock = 0;
				PlayerPrefs.SetFloat ( "player1GameClock", SaveDataP1GameClock );
			}

			//Check of player 2 game clock save data
			if ( PlayerPrefs.HasKey ( "player2GameClock" ) )
			{
				//Load save data
				SaveDataP2GameClock = PlayerPrefs.GetFloat ( "player2GameClock" );
			}
			else
			{
				//Set empty save data
				SaveDataP2GameClock = 0;
				PlayerPrefs.SetFloat ( "player2GameClock", SaveDataP2GameClock );
			}
		}
	}
}
