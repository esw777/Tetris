/*
 * Project: Tetris
 * FileName: PlayerInput.cs
 * Author: Eric W.
 * Date Created 1/6/2015
 * Rights reserved.
 */

using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour 
{
	private int storedPlayerInput = 0;

	public int getPlayerInput()
	{
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			storedPlayerInput = 1;
		}

		else if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			storedPlayerInput = 2;
		}

		else if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			storedPlayerInput = 3;
		}

		else if (Input.GetKeyDown(KeyCode.Space))
		{
			storedPlayerInput = 4;
		}

		else
		{

		}

		return storedPlayerInput;
	}

	public void playerInputCycle()
	{
		storedPlayerInput = 0;
	}
}
