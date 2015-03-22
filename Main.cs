/*
 * Project: Tetris
 * FileName: Main.cs
 * Author: Eric W.
 * Date Created 1/6/2015
 * Rights reserved.
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Main : MonoBehaviour 
{
	private GameBoard m_gameBoard;
	private ShapeMaker m_shapeMaker;
	private PlayerInput m_playerInput;
	private GameOver m_GameOver;
	private int m_width;
	private int m_height;
	private bool gameOver;
	private int lastPlayerInput;
	
	// Use this for initialization
	void Start () 
	{
		//Intitalize Components.
		m_gameBoard = (GameBoard)(GameObject.Find("o_GameBoard")).GetComponent(typeof(GameBoard));
		m_shapeMaker = (ShapeMaker)(GameObject.Find("o_ShapeMaker")).GetComponent(typeof(ShapeMaker));
		m_playerInput = (PlayerInput)(GameObject.Find("o_PlayerInput")).GetComponent(typeof(PlayerInput));
		m_GameOver = (GameOver)(GameObject.Find("img_GameOver")).GetComponent(typeof(GameOver));

		m_width = 12;
		m_height = 24;
		gameOver = false;
		lastPlayerInput = 0;

		//Init functions
		Debug.Log("Intit 1");
		m_gameBoard.initGameBoard(m_width, m_height);
		Debug.Log("Intit 2");
		m_shapeMaker.initShapeMaker(m_gameBoard);
		Debug.Log("Intit 3");
	} //end start

	int timerTmp = 0;
	
	// Update is called once per frame
	void Update () 
	{
		if (!gameOver)
		{
			lastPlayerInput = m_playerInput.getPlayerInput();

			switch (lastPlayerInput)
			{
			case 0: // no input
			{
				break;
			}
				
			case 1: //Left
			{
				m_shapeMaker.moveShape(m_gameBoard, ShapeMaker.Direction.Left);
				m_playerInput.playerInputCycle();
				break;
			}
				
			case 2: //Down
			{
				m_shapeMaker.moveShape(m_gameBoard, ShapeMaker.Direction.Down);
				m_shapeMaker.moveShape(m_gameBoard, ShapeMaker.Direction.Down);
				m_playerInput.playerInputCycle();
				break;
			}
				
			case 3: //Right
			{
				m_shapeMaker.moveShape(m_gameBoard, ShapeMaker.Direction.Right);
				m_playerInput.playerInputCycle();
				break;
			}
				
			case 4: //Space (rotate)
			{
				m_shapeMaker.moveShape(m_gameBoard, ShapeMaker.Direction.Rotate);
				m_playerInput.playerInputCycle();
				break;
			}
				
			default:
			{
				break;
				//do nothing
			}
			}//end player input switch

			if (timerTmp == 12)
			{
				if (m_shapeMaker.getActiveShapeStatus())
				{
					//always try to move down each tick.
					m_shapeMaker.moveShape(m_gameBoard, ShapeMaker.Direction.Down);

					timerTmp = 0;
				}
				
				else
				{
					m_shapeMaker.spawnShape(); 
				}
			}

			else
			{
				timerTmp++;
			}

			gameOver = m_gameBoard.getGameOver();
			if (gameOver)
			{
				m_GameOver.setGameOver(true);
			}
		}//gameOver if
	} //end update()
}