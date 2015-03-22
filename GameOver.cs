/*
 * Project: Tetris
 * FileName: GameOver.cs
 * Author: Eric W.
 * Date Created 1/6/2015
 * Rights reserved.
 */

using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour 
{
	//I know this is a horrible way of doing this.
	public void setGameOver(bool isOver)
	{
		if (isOver)
		{
			//moves text on-screen
			this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -0.5f);
		}

		else
		{
			//moves text off-screen
			this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -2f);
		}
	}
}
